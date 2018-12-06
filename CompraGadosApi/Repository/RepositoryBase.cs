using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace CompraGadosApi.Repository
{
    public abstract class RepositoryBase
    {
        public static IDbConnection Connection
        {
            get
            {
                var builder = new ConfigurationBuilder ()
                    .SetBasePath (Directory.GetCurrentDirectory ())
                    .AddJsonFile ("appsettings.json", optional : true, reloadOnChange : true);

                IConfigurationRoot configuration = builder.Build ();

                var connectionString = configuration.GetConnectionString ("DefaultConnection");
                var conn = new SqlConnection(connectionString);
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