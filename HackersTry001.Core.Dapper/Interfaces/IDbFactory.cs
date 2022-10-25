using HackersTry001.Core.Dapper.DapperBase;

namespace HackersTry001.Core.Common.Dapper.Interfaces
{
    public interface IDbFactory
    {
        int? InsertEntity<TEntity>(string connectionString, TEntity entity) where TEntity : BaseEntity;
        bool UpdateEntity<TEntity>(string connectionString, TEntity entity) where TEntity : BaseEntity;
        IQueryable<TResult> GetAll<TResult>(string connectionString) where TResult : BaseEntity;
        TResult GetSingle<TResult>(string connectionString, int id) where TResult : BaseEntity;
    }
}