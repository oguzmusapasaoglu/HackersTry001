using HackersTry001.Core.Common.Base;
using HackersTry001.Domain.Users.Data.Interfaces;
using HackersTry001.Domain.Users.Models.Entities;

namespace HackersTry001.Domain.Users.Data.Services
{
    public class UserInfoServices : IUserInfoServices
    {
        public ResponseBase<UserInfoEntity> Create(UserInfoEntity request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<IQueryable<UserInfoEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ResponseBase<IQueryable<UserInfoEntity>> GetAll(UserInfoEntity request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoEntity> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoEntity> GetSingle(UserInfoEntity request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase<UserInfoEntity> Update(UserInfoEntity request)
        {
            throw new NotImplementedException();
        }
=======
using HackersTry001.Domain.Users.Models.Models;

namespace HackersTry001.Domain.Users.Data.Services
{
    public class UserInfoServices 
    {
      
>>>>>>> 58425c03dee0e00e62efde3e2dfbb137d4684607
    }
}
