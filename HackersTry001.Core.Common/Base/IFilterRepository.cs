namespace HackersTry001.Core.Common.Base
{
    public interface IFilterRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetSingle(int id);
    }
}
