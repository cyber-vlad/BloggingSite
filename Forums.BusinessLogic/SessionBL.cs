using System.Threading.Tasks;
using AutoMapper;
using Forums.BusinessLogic.Core;
using Forums.BusinessLogic.DBModel;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Response;
using Forums.Domain.Entities.User;
using Microsoft.AspNetCore.Http;

namespace Forums.BusinessLogic
{
    public class SessionBL : SessionAPI, IMySession
    {
        public SessionBL(SessionContext sessionContext)
            : base( sessionContext)
        {
        }

        public Task<string> GenCookieAsync(string loginCredential)
        {
            return CreateCookieAsync(loginCredential);
        }
    }
}
