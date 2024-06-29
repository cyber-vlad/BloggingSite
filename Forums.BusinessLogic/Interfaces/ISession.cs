using Forums.Domain.Entities.Response;
using Forums.Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Forums.BusinessLogic.Interfaces
{
    public interface IMySession
    {
        Task<string> GenCookieAsync(string loginCredential);
        Task<Session> GetSessionByCookieAsync(string cookie);
    }
}
