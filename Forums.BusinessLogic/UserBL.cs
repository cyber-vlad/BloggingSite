using System.Threading.Tasks;
using AutoMapper;
using Forums.BusinessLogic.Core;
using Forums.BusinessLogic.DBModel;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Response;
using Forums.Domain.Entities.User;

namespace Forums.BusinessLogic
{
    public class UserBL : UserAPI, IUser
    {
        public UserBL(UserContext userContext, IMapper mapper)
            : base(userContext, mapper)
        {
        }

        public Task<UserMinimal> GetUserDataActionAsync(int ID)
        {
            return GetUserDataByIdAsync(ID);
        }
        public Task<UserMinimal> GetUserByCookieAsync(Session session)
        {
            return GetUserBySessionAsync(session);
        }

        public Task<GeneralResp> EditUserDataActionAsync(UserMinimal data, int ID)
        {
            return EditUserDataAsync(data, ID);
        }

        public Task<GeneralResp> DeleteUserActionAsync(int ID)
        {
            return DeleteUserAsync(ID);
        }

        public Task<GeneralResp> UploadPhotoActionAsync(string photo, int ID)
        {
            return UploadPhotoAsync(photo, ID);
        }

        public Task<GeneralResp> UserPassCheckActionAsync(ULoginData data)
        {
            return UserAuthLogicAsync(data);
        }

        public Task<GeneralResp> RegisterNewUserActionAsync(URegisterData data)
        {
            return RegisterUserActionAsync(data);
        }
        public Task<GeneralResp> ResetPasswordActionAsync(string email, string password)
        {
            return ResetPasswordAsync(email, password);
        }

        public Task<GeneralResp> SendEmailToUserActionAsync(string email, string name, string subject, string body)
        {
            return SendEmailAsync(email, name, subject, body);
        }


        public Task<GeneralResp> ExistingEmailInDBAsync(string email)
        {
            return ExistingEmailAsync(email);
        }
    }
}
