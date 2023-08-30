using Dapper;
using Npgsql;

namespace Week35
{
    public class DatabaseConnector
    {
        private static string _connectionString = @"
        User ID=xsxmxiiw;
        Password=2TYFrLDyFVsDhgVpYGxd32GNEoP64nRI;
        Host=snuffleupagus.db.elephantsql.com;
        Port=5432;
        Database=xsxmxiiw;
        Pooling=true;Min Pool Size=0;Max Pool Size=100;
        Connection Lifetime=0;
    ";

        private DatabaseConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static void Init(string connectionString)
        {
            new DatabaseConnector(connectionString);
        }
    }
}