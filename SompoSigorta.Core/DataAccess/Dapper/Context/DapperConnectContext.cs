using SompoSigorta.Core.Helper;
using System.Data.SqlClient;

namespace SompoSigorta.Core.DataAccess.Dapper.Context
{
    public class DapperConnectContext : IDapperConnectContext
    {
        public string ConStr()
        {
            return StaticHelpers.ConnectionString;
        }

        public SqlConnection sqlConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(ConStr());

            return sqlConnection;
        }

    }
}
