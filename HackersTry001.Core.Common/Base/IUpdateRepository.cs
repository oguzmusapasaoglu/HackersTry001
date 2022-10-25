namespace HackersTry001.Core.Common.Base
{
    public interface IUpdateRepository<TEntity>
        where TEntity : class
    {
        ResponseBase<TEntity> Update(TEntity request);
    }
}
