using Dapper;

using HackersTry001.Core.Dapper.Base;

using System.Data.Common;
using System.Text;

namespace HackersTry001.Core.Common.Dapper.Interfaces
{
    public interface IDbFactory
    {
        IEnumerable<TResult> GetData<TResult>(string connectionString, StringBuilder queryScript, DynamicParameters parameters);
        IEnumerable<TResult> GetData<TResult>(string connectionString, StringBuilder queryScript, object parameters);
        IEnumerable<TResult> GetDataWithSp<TResult>(string connectionString, string SpName, object parm);
        TResult GetSingleData<TResult>(string connectionString, StringBuilder queryScript, DynamicParameters parameters);
        TResult GetSingleDataWithSp<TResult>(string connectionString, string SpName, object parm);
        TResult GetSingleDataWithId<TResult>(string connectionString, StringBuilder selectClause, int parmId, DbConnection dbConnection);
        TResult InsertOrUpdate<TResult>(string connectionString, StringBuilder query, object data);
        Task<int> InsertOrUpdateAsync(string connectionString, StringBuilder query, object data);
        TResult InsertOrUpdateWithSp<TResult>(string connectionString, string SpName, object parm);
        int? InsertEntity<TEntity>(string connectionString, TEntity entity) where TEntity : BaseDapperEntity;
        bool UpdateEntity<TEntity>(string connectionString, TEntity entity) where TEntity : BaseDapperEntity;
        IQueryable<TResult> GetAll<TResult>(string connectionString) where TResult : BaseDapperEntity;
    }
}