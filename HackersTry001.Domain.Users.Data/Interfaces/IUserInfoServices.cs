using HackersTry001.Core.Common.Base;

namespace HackersTry001.Domain.Users.Data.Interfaces
{
    public interface IUserInfoServices<TModel> : ICRUD<TModel>, IFilter<TModel>
        where TModel : class
    {
    }
}