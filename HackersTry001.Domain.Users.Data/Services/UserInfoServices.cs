using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HackersTry001.Core.Common.Base;
using HackersTry001.Domain.Users.Data.Interfaces;
using HackersTry001.Domain.Users.Models;

namespace HackersTry001.Domain.Users.Data.Services
{
    public class UserInfoServices : IUserInfoServices<UserInfoModel>
    {
        public ResponseBase<UserInfoModel> Create(UserInfoModel request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoModel> Delete(UserInfoModel request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoModel> Update(UserInfoModel request)
        {
            throw new NotImplementedException();
        }
    }
}
