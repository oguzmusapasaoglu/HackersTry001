using HackersTry001.Core.Common.Base;
using HackersTry001.Domain.Users.Services.Models;

namespace HackersTry001.Domain.Users.Services.Interfaces
{
    public interface IUserInfoServices
    {
        ResponseBase<UserInfoModel> UserLogin(UserLoginModel model);
        ResponseBase<UserInfoModel> ChangePassword(UserChangePasswordModel model);
        ResponseBase<UserInfoModel> ForgotPassword(UserForgotPasswordModel model);
        ResponseBase<IQueryable<UserInfoModel>> GetAllUserByFilter(UserFilterModel model);
        ResponseBase<UserInfoModel> GetSingleUserByFilter(UserFilterModel model);
        ResponseBase<UserInfoModel> UserCreate(UserCreateOrUpdateModel model);
        ResponseBase<UserInfoModel> UserUpdate(UserCreateOrUpdateModel model);
        ResponseBase<UserInfoModel> UserDelete(UserCreateOrUpdateModel model);
    }
}