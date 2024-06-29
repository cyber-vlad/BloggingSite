using Microsoft.AspNetCore.Http;
using Forums.Domain.Entities.User;
using Newtonsoft.Json;

namespace Forums.Web.Extension
{
    public static class HttpContextExtensions
    {
        private const string SessionKey = "__SessionObject";

        public static UserMinimal GetMySessionObject(this HttpContext context)
        {
            var sessionData = context.Session.GetString(SessionKey);
            return sessionData != null ? JsonConvert.DeserializeObject<UserMinimal>(sessionData) : null;
        }

        public static void SetMySessionObject(this HttpContext context, UserMinimal profile)
        {
            var sessionData = JsonConvert.SerializeObject(profile);
            context.Session.SetString(SessionKey, sessionData);
        }
    }
}
