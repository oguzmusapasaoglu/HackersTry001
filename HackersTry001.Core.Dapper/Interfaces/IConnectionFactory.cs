using System.Data.Common;
using System.Data;

namespace HackersTry001.Core.Common.Dapper.Interfaces
{
    public interface IConnectionFactory
    {
        IDbTransaction dbTransaction { get; set; }
        DbConnection CreateConnection(string connectionStr, bool parmNeedTrans = false);
        void CloseConnection(DbConnection conn);
    }
}
