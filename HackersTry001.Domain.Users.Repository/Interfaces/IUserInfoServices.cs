using HackersTry001.Core.Common.Base;
using HackersTry001.Domain.Users.Models.Entities;

namespace HackersTry001.Domain.Users.Data.Interfaces
{
    public interface IUserInfoServices :
        ICreateRepository<UserInfoEntity>,
        IUpdateRepository<UserInfoEntity>,
        IFilterRepository<UserInfoEntity>
    {
    }
}