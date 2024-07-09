
using System.Data;
using System.Data.SQLite;

namespace Timelogger.Data
{
    public class DapperConnectionFactory
    {
        private readonly string _connectionString;

        public DapperConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}
