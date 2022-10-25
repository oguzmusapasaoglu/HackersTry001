namespace HackersTry001.Core.Common.Base
{
    public interface IFilterRepository<TEntity>
        where TEntity : class
    {
        ResponseBase<IQueryable<TEntity>> GetAll();
        ResponseBase<IQueryable<TEntity>> GetAll(TEntity request);
        ResponseBase<TEntity> GetSingle(int id);
        ResponseBase<TEntity> GetSingle(TEntity request);
    }
}
