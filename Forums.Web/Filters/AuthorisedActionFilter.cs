using Forums.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Forums.BusinessLogic;

namespace Forums.Web.Filters
{
    public class AuthorisedActionFilter : ActionFilterAttribute
    {
        private readonly IMySession _session;

        public AuthorisedActionFilter(IMySession session)
        {
            _session = session;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                var loginStatus = context.HttpContext.Session.GetString("LoginStatus");

                if (loginStatus == "login")
                {
                    controller.ViewBag.IsAuthenticated = true;
                }
                else
                {
                    controller.ViewBag.IsAuthenticated = false;
                }
            }
        }
    }
}
