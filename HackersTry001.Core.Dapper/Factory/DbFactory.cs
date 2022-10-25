using Dapper;
using HackersTry001.Core.Common.Dapper.Interfaces;
using System.Data.Common;
using System.Data;
using System.Text;
using HackersTry001.Core.Common.Dapper.Helper;
using Dapper.Contrib.Extensions;
using HackersTry001.Core.Common.ExceptionHandling;
using HackersTry001.Core.Dapper.DapperBase;

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
        public int? InsertEntity<TResult>(string connectionString, TResult entity) where TResult : BaseEntity
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

        public bool UpdateEntity<TResult>(string connectionString, TResult entity) where TResult : BaseEntity
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

        public IQueryable<TResult> GetAll<TResult>(string connectionString) where TResult : BaseEntity
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

        public TResult GetSingle<TResult>(string connectionString, int id) where TResult : BaseEntity
        {
            try
            {
                TResult result;
                using (var conn = connectionFactory.CreateConnection(connectionString))
                {
                    result = conn.Get<TResult>(id);
                    conn.Dispose();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }
    }
}