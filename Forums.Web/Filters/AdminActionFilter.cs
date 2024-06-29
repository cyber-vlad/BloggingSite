using Forums.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Forums.Web.Filters
{
    public class AdminActionFilter : IAsyncActionFilter
    {
        private readonly IUser _user;
        private readonly IMySession _session;

        public AdminActionFilter(IUser user, IMySession session)
        {
            _user = user;
            _session = session;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                var sessionTask = _session.GetSessionByCookieAsync(context.HttpContext.Request.Cookies["X-Key"]);
                var session = await sessionTask;
                if (session != null)
                {
                    var profileTask = _user.GetUserBySessionAsync(session);
                    var profile = await profileTask;
                    if (profile != null && profile.Level == Domain.Enum.UserRole.Admin)
                    {
                        controller.ViewBag.IsAdmin = true;
                    }
                    else
                    {
                        controller.ViewBag.IsAdmin = false;
                    }
                }
                else
                {
                    controller.ViewBag.IsAdmin = false;
                }
            }

            await next(); // Call the next action filter or the action method itself
        }
    }
}
