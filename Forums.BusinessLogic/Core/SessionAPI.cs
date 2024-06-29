using Forums.BusinessLogic.DBModel;
using Forums.Domain.Entities.User;
using Forums.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BusinessLogic.Core
{
    public class SessionAPI
    {
        private readonly SessionContext _sessionContext;

        public SessionAPI(SessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        public async Task<string> CreateCookieAsync(string loginCredential)
        {
            var apiCookie = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(60).UtcDateTime // Convert DateTimeOffset to DateTime
            };

            var validate = new EmailAddressAttribute();
            var curent = validate.IsValid(loginCredential)
                ? await _sessionContext.Sessions.FirstOrDefaultAsync(e => e.Username == loginCredential)
                : await _sessionContext.Sessions.FirstOrDefaultAsync(e => e.Username == loginCredential);

            var cookieValue = CookieGenerator.Create(loginCredential);

            if (curent != null)
            {
                curent.CookieString = cookieValue;
                curent.ExpireTime = DateTime.Now.AddMinutes(60);
                _sessionContext.Sessions.Update(curent);
            }
            else
            {
                await _sessionContext.Sessions.AddAsync(new Session
                {
                    Username = loginCredential,
                    CookieString = cookieValue,
                    ExpireTime = DateTime.Now.AddMinutes(60)
                });
            }

            await _sessionContext.SaveChangesAsync();
            return cookieValue;
        }

        public async Task<Session> GetSessionByCookieAsync(string cookie)
        {
            return await _sessionContext.Sessions.FirstOrDefaultAsync(s => s.CookieString == cookie && s.ExpireTime > DateTimeOffset.Now);
        }
    }
}
