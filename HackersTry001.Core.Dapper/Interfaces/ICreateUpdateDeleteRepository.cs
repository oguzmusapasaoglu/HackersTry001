using HackersTry001.Core.Dapper.Base;

namespace HackersTry001.Core.Common.Dapper.Interfaces
{
    public interface ICreateUpdateDeleteRepository<TEntity>
        where TEntity : BaseDapperEntity
    {
        TEntity Create(TEntity request, int requestUserPKey);
        TEntity Update(TEntity request, int requestUserPKey);
        TEntity Delete(TEntity request, int requestUserPKey);
    }
}
