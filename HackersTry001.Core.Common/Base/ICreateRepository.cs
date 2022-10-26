namespace HackersTry001.Core.Common.Base
{
    public interface ICreateRepository<TEntity>
        where TEntity : class
    {
        TEntity Create(TEntity request);
    }
}
