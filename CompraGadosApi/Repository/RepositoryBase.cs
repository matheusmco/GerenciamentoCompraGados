using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace CompraGadosApi.Repository
{
    public abstract class RepositoryBase
    {
        public static IDbConnection Connection
        {
            get
            {
                var conn = new SqlConnection(""); //TODO: pegar de app.settings
                conn.Open();
                // conn.Execute("Set Transaction Isolation Level Read UnCommitted");
                return conn;
            }
        }

        public RepositoryBase()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}