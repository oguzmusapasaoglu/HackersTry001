using HackersTry001.Core.Common.Dapper.Factory;
using HackersTry001.Core.Common.Dapper.Interfaces;
using HackersTry001.Core.Common.ExceptionHandling;
using HackersTry001.Core.Common.Helper;
using HackersTry001.Domain.Users.Data.Interfaces;
using HackersTry001.Domain.Users.Models.Entities;

namespace HackersTry001.Domain.Users.Repository.Services
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private IDbFactory dbFactory;
        private string connectionString => ConfigurationHelper.GetTConfig<SqlServerConfig>(SqlServerConfig.SectionName).ConnectionStr;
        public UserInfoRepository()
        {
            dbFactory = new DbFactory();
        }

        #region Create Update Delete
        public UserInfoEntity Create(UserInfoEntity request)
        {
            if (request.ID.HasValue)
                throw new NotificationException("ID alanı set edilemez!", ExceptionTypeEnum.Warn);

            DataControl(request);
            request.ID = dbFactory.InsertEntity(connectionString, request);
            if (!request.ID.HasValue)
                throw new NotificationException("Kayıt başarısız!", ExceptionTypeEnum.Warn);
            return request;
        }

        public UserInfoEntity Update(UserInfoEntity request)
        {
            if (!request.ID.HasValue)
                throw new NotificationException("ID alanı set edilmeli!", ExceptionTypeEnum.Warn);

            DataControl(request);
            if (!dbFactory.UpdateEntity(connectionString, request))
                throw new NotificationException("Kayıt başarısız!", ExceptionTypeEnum.Warn);
            return request;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new NotificationException("ID alanı set edilmeli!", ExceptionTypeEnum.Warn);
            var user = GetSingle(id);
            user.Status = (int)ActivationStatusEnum.Deleted;
            if (!dbFactory.UpdateEntity(connectionString, user))
                throw new NotificationException("Kayıt başarısız!", ExceptionTypeEnum.Warn);
            return false;
        }

        private void DataControl(UserInfoEntity request)
        {
            var data = GetAll();
            var user = data.FirstOrDefault(h => h.UserName == request.UserName || h.Email == request.Email);

            if (!request.ID.HasValue && user != null)
                throw new NotificationException("Bu data kullanımdadır", ExceptionTypeEnum.Warn);

            if (user != null && user.ID != request.ID)
                throw new NotificationException("Bu data kullanımdadır", ExceptionTypeEnum.Warn);
        }
        #endregion

        #region Filter Methods
        public IQueryable<UserInfoEntity> GetAll()
        {
            return dbFactory.GetAll<UserInfoEntity>(connectionString);
        }

        public UserInfoEntity GetSingle(int id)
        {
            return dbFactory.GetSingle<UserInfoEntity>(connectionString, id);
        }
        #endregion
    }
}
