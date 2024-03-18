using Microsoft.Data.SqlClient;
using System.Data;

namespace JobPortal.API.Models.Data
{
    public class DapperDBConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        public DapperDBConnection(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionstring = this._configuration.GetConnectionString("serverConnection");

        }
        public IDbConnection CreateConnection() => new SqlConnection(this._connectionstring);
    }
}
