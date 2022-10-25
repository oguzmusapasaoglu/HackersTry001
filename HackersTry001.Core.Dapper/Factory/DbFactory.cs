using Dapper;
using HackersTry001.Core.Common.Dapper.Interfaces;
using System.Data.Common;
using System.Data;
using System.Text;
using HackersTry001.Core.Common.Dapper.Helper;
using Dapper.Contrib.Extensions;
using HackersTry001.Core.Dapper.Base;
using HackersTry001.Core.Common.ExceptionHandling;

namespace HackersTry001.Core.Common.Dapper.Factory
{
    public class DbFactory : IDbFactory
    {
        private IConnectionFactory connectionFactory;
        //public DbFactory(IConnectionFactory _connectionFactory)
        //{
        //    connectionFactory = _connectionFactory; ;
        //}
        public DbFactory()
        {
            connectionFactory = new ConnectionFactory();
        }
        public IEnumerable<TResult> GetData<TResult>(string connectionString, StringBuilder queryScript, DynamicParameters parameters)
        {
            try
            {
                using (var conn = connectionFactory.CreateConnection(connectionString, false))
                {
                    var result = conn.Query<TResult>(queryScript.ToString(), parameters);
                    connectionFactory.CloseConnection(conn);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public IEnumerable<TResult> GetData<TResult>(string connectionString, StringBuilder queryScript, object parameters)
        {
            try
            {
                using (var conn = connectionFactory.CreateConnection(connectionString, false))
                {
                    var result = conn.Query<TResult>(queryScript.ToString(), parameters);
                    connectionFactory.CloseConnection(conn);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public IEnumerable<TResult> GetDataWithSp<TResult>(string connectionString, string SpName, object parm)
        {
            try
            {
                using (var conn = connectionFactory.CreateConnection(connectionString, false))
                {
                    var result = conn.Query<TResult>(SpName, parm, commandType: CommandType.StoredProcedure);
                    connectionFactory.CloseConnection(conn);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public TResult GetSingleData<TResult>(string connectionString, StringBuilder queryScript, DynamicParameters parameters)
        {
            try
            {
                using (var conn = connectionFactory.CreateConnection(connectionString, false))
                {
                    var result = conn.QueryFirstOrDefault<TResult>(queryScript.ToString(), parameters, null, 1000, CommandType.Text);
                    connectionFactory.CloseConnection(conn);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public TResult GetSingleDataWithSp<TResult>(string connectionString, string SpName, object parm)
        {
            try
            {
                using (var conn = connectionFactory.CreateConnection(connectionString, false))
                {
                    var result = conn.QueryFirst<TResult>(SpName, parm, commandType: CommandType.StoredProcedure);
                    connectionFactory.CloseConnection(conn);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public TResult GetSingleDataWithId<TResult>(string connectionString, StringBuilder selectClause, int parmId, DbConnection dbConnection)
        {
            try
            {
                using (var conn = connectionFactory.CreateConnection(connectionString, false))
                {
                    var result = conn.QuerySingle<TResult>(selectClause.ToString(), new { Id = parmId });
                    if (dbConnection == null)
                        connectionFactory.CloseConnection(conn);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public TResult InsertOrUpdate<TResult>(string connectionString, StringBuilder query, object data)
        {
            try
            {
                var connection = connectionFactory.CreateConnection(connectionString, true);
                connection.Execute(query.ToString(), data, connectionFactory.dbTransaction);
                var Id = (int)connection.Query(@"select @@IDENTITY as ID").First().ID;
                var sb = new StringBuilder();
                sb.AppendFormat("SELECT * FROM {0} WHERE Id = {1}", DapperHelper.GetTableName<TResult>(), Id);
                var Result = connection.QueryFirst<TResult>(sb.ToString());
                connectionFactory.dbTransaction.Commit();
                connectionFactory.CloseConnection(connection);
                return Result;
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public async Task<int> InsertOrUpdateAsync(string connectionString, StringBuilder query, object data)
        {
            try
            {
                int id = 0;
                using (var conn = connectionFactory.CreateConnection(connectionString))
                {
                    var result = await conn.QueryAsync<int>(query.ToString(), data, connectionFactory.dbTransaction);
                    connectionFactory.dbTransaction.Commit();
                    connectionFactory.CloseConnection(conn);
                    id = result.ToInt();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public TResult InsertOrUpdateWithSp<TResult>(string connectionString, string SpName, object parm)
        {
            try
            {
                var connection = connectionFactory.CreateConnection(connectionString);
                var result = connection.ExecuteScalar<TResult>(SpName, parm, commandType: CommandType.StoredProcedure);
                connectionFactory.CloseConnection(connection);
                return result;
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public int? InsertEntity<TResult>(string connectionString, TResult entity) where TResult : BaseDapperEntity
        {
            try
            {
                int? Pkey;
                using (var conn = connectionFactory.CreateConnection(connectionString, true))
                {
                    Pkey = conn.Insert(entity, connectionFactory.dbTransaction).ToInt();
                    connectionFactory.dbTransaction.Commit();
                    conn.Dispose();
                }
                return Pkey;
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public bool UpdateEntity<TResult>(string connectionString, TResult entity) where TResult : BaseDapperEntity
        {
            try
            {
                bool result;
                using (var conn = connectionFactory.CreateConnection(connectionString, true))
                {
                    result = conn.Update(entity, connectionFactory.dbTransaction);
                    connectionFactory.dbTransaction.Commit();
                    conn.Dispose();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }

        public IQueryable<TResult> GetAll<TResult>(string connectionString) where TResult : BaseDapperEntity
        {
            try
            {
                IEnumerable<TResult> result;
                using (var conn = connectionFactory.CreateConnection(connectionString))
                {
                    result = conn.GetAll<TResult>();
                    conn.Dispose();
                }
                return result.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }
    }
}