using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Response;
using Forums.Web.Models;
using Microsoft.AspNetCore.Http;

namespace Forums.Web.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly IUser _user;

        public ResetPasswordController(IUser user)
        {
            _user = user;
        }

        // GET: ResetPassword
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserRegister uRegis)
        {
            if (!string.IsNullOrEmpty(uRegis.Email))
            {
                GeneralResp resp = await _user.ExistingEmailInDBAsync(uRegis.Email);
                if (!resp.Status)
                {
                    return View(uRegis);
                }

                HttpContext.Session.Remove("ResetToken");
                HttpContext.Session.Remove("ResetTokenExpiration");
                HttpContext.Session.Remove("Email");

                string token = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("ResetToken", token);
                HttpContext.Session.SetString("ResetTokenExpiration", DateTime.Now.AddMinutes(5).ToString());
                HttpContext.Session.SetString("Email", uRegis.Email);

                string resetLink = Url.Action("Reset", "ResetPassword", new { token = token, email = uRegis.Email }, protocol: Request.Scheme);
                var response = await _user.SendEmailToUserActionAsync(uRegis.Email, "Name", "Reset your password", $"Please reset your password by clicking on this link: {resetLink}");

                return Json(new { success = response.Status });
            }
            return View(uRegis);
        }

        public IActionResult Reset(string token, string email)
        {
            var resetTokenExpirationString = HttpContext.Session.GetString("ResetTokenExpiration");
            DateTime? resetTokenExpiration = resetTokenExpirationString != null ? (DateTime?)DateTime.Parse(resetTokenExpirationString) : null;

            if (HttpContext.Session.GetString("ResetToken") == token && HttpContext.Session.GetString("Email") == email && resetTokenExpiration.HasValue && resetTokenExpiration.Value > DateTime.Now)
            {
                HttpContext.Session.SetString("Email", email);
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ResettingProcess(UserRegister data)
        {
            var email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(data.Password) || string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index");
            }

            GeneralResp resp = await _user.ResetPasswordActionAsync(email, data.Password);
            HttpContext.Session.Remove("ResetToken");
            HttpContext.Session.Remove("ResetTokenExpiration");
            HttpContext.Session.Remove("Email");
            return Json(new { success = resp.Status });
        }
    }
}
