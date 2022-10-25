using HackersTry001.Core.Common.Dapper.Interfaces;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using HackersTry001.Core.Common.ExceptionHandling;

namespace HackersTry001.Core.Common.Dapper.Factory
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbTransaction dbTransaction { get; set; }
        public DbConnection CreateConnection(string connectionStr, bool parmNeedTrans = false)
        {
            try
            {
                var connection = new SqlConnection(connectionStr);
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                if (parmNeedTrans)
                    dbTransaction = connection.BeginTransaction();
                return connection;
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }
        public void CloseConnection(DbConnection conn)
        {
            try
            {
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw new KnownException(ExceptionTypeEnum.Fattal, ex);
            }
        }
    }
}
