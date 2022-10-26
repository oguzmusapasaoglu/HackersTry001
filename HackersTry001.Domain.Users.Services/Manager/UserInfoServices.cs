using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HackersTry001.Core.Common.Base;
using HackersTry001.Core.Common.ExceptionHandling;
using HackersTry001.Core.Common.Helper;
using HackersTry001.Domain.Users.Data.Interfaces;
using HackersTry001.Domain.Users.Models.Entities;
using HackersTry001.Domain.Users.Repository.Services;
using HackersTry001.Domain.Users.Services.Interfaces;
using HackersTry001.Domain.Users.Services.Models;

namespace HackersTry001.Domain.Users.Services.Manager
{
    public class UserInfoServices : IUserInfoServices
    {
        private IUserInfoRepository userInfoRepository;
        public UserInfoServices()
        {
            userInfoRepository = new UserInfoRepository();
        }

        #region Get Method
        public ResponseBase<UserInfoModel> ChangePassword(UserChangePasswordModel model)
        {
            try
            {
                if (model.NewPassword.IsNullOrEmpty() || model.OldPassword.IsNullOrEmpty())
                    return ErrorResponse("Şifre alanı boş geçilemez!");

                var userData = userInfoRepository.GetAll();
                var userEntity = userData.FirstOrDefault(q => q.UserName == model.UserName);
                if (userEntity == null)
                    return ErrorResponse("Kullanıcı bulunamadı!");

                if (userEntity.Password == PasswordHelper.HashPassword(model.UserName, model.OldPassword))
                    return ErrorResponse("Eski şifre hatası!");

                userEntity.Password = PasswordHelper.HashPassword(model.UserName, model.NewPassword);

                userInfoRepository.Update(userEntity);
                return SuccessResponse(FillUserModel(userEntity));
            }
            catch (KnownException kex)
            {
                return ErrorResponse(kex.Message, ResultEnum.Error);
            }
            catch (NotificationException nex)
            {
                return ErrorResponse(nex.Message);
            }
        }

        public ResponseBase<UserInfoModel> ForgotPassword(UserForgotPasswordModel model)
        {            
            //TODO: Murat
            throw new NotImplementedException();
        }

        public ResponseBase<IQueryable<UserInfoModel>> GetAllUserByFilter(UserFilterModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoModel> GetSingleUserByFilter(UserFilterModel model)
        {
            //TODO : Ahmet (Sadece ID' ile sorgula!)
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoModel> UserLogin(UserLoginModel model)
        {
            //TODO: Ayşe
            throw new NotImplementedException();
        }
        #endregion

        #region CUD
        public ResponseBase<UserInfoModel> UserCreate(UserCreateOrUpdateModel model)
        {
            //Ayşe
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoModel> UserDelete(UserCreateOrUpdateModel model)
        {            
            //Murat
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoModel> UserUpdate(UserCreateOrUpdateModel model)
        {
            //Ahmet
            throw new NotImplementedException();
        }
        #endregion

        private ResponseBase<UserInfoModel> ErrorResponse(string errorMessage, ResultEnum resultValue = ResultEnum.Warning)
        {
            return new ResponseBase<UserInfoModel>
            {
                Message = errorMessage,
                Result = resultValue
            };
        }

        private ResponseBase<UserInfoModel> SuccessResponse(UserInfoModel userInfoModel)
        {
            return new ResponseBase<UserInfoModel>
            {
                Data = userInfoModel,
                Message = "İşlem başarılı!",
                Result = ResultEnum.Success
            };
        }
        private UserInfoModel FillUserModel(UserInfoEntity userEntity)
        {
            return new UserInfoModel
            {
                UserName = userEntity.UserName
                //TODO: Burası doldurulacak!
            };
        }
    }
}
