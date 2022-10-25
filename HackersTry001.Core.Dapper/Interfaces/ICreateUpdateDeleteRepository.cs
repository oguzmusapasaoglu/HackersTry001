using HackersTry001.Core.Dapper.DapperBase;

namespace HackersTry001.Core.Common.Dapper.Interfaces
{
    public interface ICreateUpdateDeleteRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity Create(TEntity request, int requestUserPKey);
        TEntity Update(TEntity request, int requestUserPKey);
        TEntity Delete(TEntity request, int requestUserPKey);
    }
}
