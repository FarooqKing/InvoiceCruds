using Microsoft.Data.SqlClient;
using System.Data;

namespace InvoiceCruds.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("database");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
