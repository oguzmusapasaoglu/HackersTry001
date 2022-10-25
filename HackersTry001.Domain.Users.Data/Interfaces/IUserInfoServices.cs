using HackersTry001.Core.Common.Base;

namespace HackersTry001.Domain.Users.Data.Interfaces
{
    public interface IUserInfoServices<TModel> : ICreateRepository<TModel>, IFilterRepository<TModel>
        where TModel : class
    {
    }
}