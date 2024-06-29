using Forums.Domain.Entities.Response;
using Forums.Domain.Entities.User;
using System.Threading.Tasks;

namespace Forums.BusinessLogic.Interfaces
{
    public interface IUser
    {
        Task<UserMinimal> GetUserDataByIdAsync(int ID);
        Task<UserMinimal> GetUserBySessionAsync(Session session);
        Task<GeneralResp> EditUserDataActionAsync(UserMinimal data, int ID);
        Task<GeneralResp> DeleteUserActionAsync(int ID);
        Task<GeneralResp> UploadPhotoActionAsync(string photo, int ID);
        Task<GeneralResp> UserPassCheckActionAsync(ULoginData data);
        Task<GeneralResp> RegisterNewUserActionAsync(URegisterData data);
        Task<GeneralResp> ResetPasswordActionAsync(string email, string password);
        Task<GeneralResp> SendEmailToUserActionAsync(string email, string name, string subject, string body);
        Task<GeneralResp> ExistingEmailInDBAsync(string email);
    }
}
