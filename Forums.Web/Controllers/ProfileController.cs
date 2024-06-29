using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Response;
using Forums.Domain.Entities.User;
using Forums.Web.Extension;
using Forums.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Forums.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUser _user;
        private readonly IPost _post;
        private readonly IWebHostEnvironment _environment;

        public ProfileController(IUser user,IPost post, IWebHostEnvironment environment)
        {
            _user = user;
            _post = post;
            _environment = environment;
        }

        // Logging out of session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("LoginStatus");
            DeleteCookies();

            return RedirectToAction("HomePage", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser()
        {
            var user = HttpContext.GetMySessionObject();
            var userData = await _user.GetUserDataByIdAsync(user.Id);
            var oldFilePath = Path.Combine(_environment.WebRootPath, userData.Photo.TrimStart('~'));

            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            GeneralResp postResp = await _post.DeleteUserPosts(user.Id);
            GeneralResp userResp = await _user.DeleteUserActionAsync(user.Id);
            if (userResp.Status && postResp.Status)
            {
                HttpContext.Session.Clear();
                HttpContext.Session.Remove("LoginStatus");
                DeleteCookies();

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UsersPostsViewModel data)
        {
            var user = HttpContext.GetMySessionObject();
            if (ModelState.IsValid)
            {
                data.Fullname = data.Fullname ?? String.Empty;
                data.InfoBlog = data.InfoBlog ?? String.Empty;
                data.Profession = data.Profession ?? String.Empty;
                data.PhoneNumber = data.PhoneNumber ?? String.Empty;

                var dataUser = new UserMinimal
                {
                    Fullname = data.Fullname,
                    Email = data.Email,
                    InfoBlog = data.InfoBlog,
                    Profession = data.Profession,
                    PhoneNumber = data.PhoneNumber,
                };

                GeneralResp resp = await _user.EditUserDataActionAsync(dataUser, user.Id);

                if (resp.Status)
                {
                    TempData["SuccessMessage"] = "Profile updated successfully!";
                }
            }
            return RedirectToAction("Index", "Profile");
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.GetMySessionObject();
            SessionStatus();

            if (HttpContext.Session.GetString("LoginStatus") != "login")
            {
                return RedirectToAction("HomePage", "Home");
            }

            var userByID = await _user.GetUserDataByIdAsync(user.Id);
            var userPosts = await _post.GetUserPosts(user.Id);
           
            var currentUser = new UsersPostsViewModel()
            {
                    Username = userByID.Username,
                    Fullname = userByID.Fullname,
                    Email = userByID.Email,
                    InfoBlog = userByID.InfoBlog,
                    Photo = userByID.Photo,
                    PhoneNumber = userByID.PhoneNumber,
                    Profession = userByID.Profession,
                    Posts = userPosts.Select(post => new PostData
                    {
                        Id = post.Id,
                        Content = post.Content,
                        Title = post.Title,
                        DateOfCreation = post.DateOfCreation
                    }).ToList()
            };
            return View(currentUser);
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto()
        {
            var user = HttpContext.GetMySessionObject();
            var userData = await _user.GetUserDataByIdAsync(user.Id);
            string fileName = String.Empty;
            string filePath = String.Empty;
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpeg", ".jpg", ".png" };
                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        return Json(new { status = false });
                    }
                    var oldFilePath = Path.Combine(_environment.WebRootPath, userData.Photo.TrimStart('~'));

                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_environment.WebRootPath, "Uploads", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Path.GetFileName(userData.Photo);
            }

            userData.Photo = "~/Uploads/" + fileName;

            var photoUrl = Url.Content("~/Uploads/" + fileName);
            var uploadResult = await _user.UploadPhotoActionAsync(userData.Photo, user.Id);
            return Json(new { status = uploadResult.Status, photoUrl = photoUrl });
        }

        // Delete cookie
        private void DeleteCookies()
        {
            if (Request.Cookies["X-KEY"] != null)
            {
                Response.Cookies.Delete("X-KEY");
            }
        }

        private void SessionStatus()
        {
            if (HttpContext.Session.GetString("LoginStatus") == null)
            {
                HttpContext.Session.SetString("LoginStatus", "logout");
            }
        }
    }
}
