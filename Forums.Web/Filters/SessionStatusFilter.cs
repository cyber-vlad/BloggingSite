using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Forums.BusinessLogic.Interfaces;
using Forums.Web.Extension;

public class SessionStatusFilter : IAsyncActionFilter
{
    private readonly IMySession _session;
    private readonly IUser _user;

    public SessionStatusFilter(IMySession session, IUser user)
    {
        _session = session;
        _user = user;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var session = await _session.GetSessionByCookieAsync(context.HttpContext.Request.Cookies["X-KEY"]);
        if (session != null)
        {
            var profile = await _user.GetUserBySessionAsync(session);
            if (profile != null)
            {
                context.HttpContext.SetMySessionObject(profile);
                context.HttpContext.Session.SetString("LoginStatus", "login");
            }
            else
            {
                context.HttpContext.Session.Clear();
                if (context.HttpContext.Request.Cookies.ContainsKey("X-KEY"))
                {
                    context.HttpContext.Response.Cookies.Delete("X-KEY");
                }

                context.HttpContext.Session.SetString("LoginStatus", "logout");
            }
        }
        else
        {
            context.HttpContext.Session.SetString("LoginStatus", "logout");
        }

        await next();
    }
}
