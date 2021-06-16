using System.Data.SqlClient;

namespace SompoSigorta.Core.DataAccess.Dapper.Context
{
    public interface IDapperConnectContext
    {
        string ConStr();

        SqlConnection sqlConnection();
    }
}