using Azure;
using Forums.BusinessLogic;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Posts;
using Forums.Domain.Entities.Response;
using Forums.Web.Extension;
using Forums.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Forums.Web.Controllers
{

    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IMySession _session;

        public PostController(IPost postService, IMySession session)
                {
                    _postService = postService;
                    _session = session;
                }

        public IActionResult Index()
        {
            var loginStatus = HttpContext.Session.GetString("LoginStatus");
            ViewBag.IsAuthenticated = loginStatus == "login";
            if (ViewBag.IsAuthenticated == true)
            {
                return View();
            }
            else
            {
               return RedirectToAction("Index", "Login"); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(PostData postData)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.GetMySessionObject();
                if (user != null)
                {
                    var postD = new Post
                    {
                        Content = postData.Content,
                        Title = postData.Title,
                        AuthorId = user.Id,
                        DateOfCreation = DateTime.Now,
                    };

                    GeneralResp generalResp = await _postService.SavePost(postD);

                    if (generalResp.Status)
                    {
                        return RedirectToAction("HomePage", "Home"); 
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, generalResp.StatusMsg);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login"); 
                }
            }

            return View(postData); 
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            GeneralResp response = await _postService.DeletePost(id);
            if (response.Status)
            {
                return Json(new { success = true});
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
