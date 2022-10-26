using HackersTry001.Core.Common.Base;
using HackersTry001.Domain.Users.Models.Entities;

namespace HackersTry001.Domain.Users.Data.Interfaces
{
    public interface IUserInfoRepository :
        ICreateRepository<UserInfoEntity>,
        IUpdateRepository<UserInfoEntity>,
        IDeleteRepository,
        IFilterRepository<UserInfoEntity>
    {
    }
}