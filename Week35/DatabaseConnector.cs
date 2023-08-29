using Dapper;
using Npgsql;
namespace Week35
{
    public class DatabaseConnector
    {
        private static string _connectionString;

        private DatabaseConnector(string connectionString) {
            _connectionString = connectionString;
        }        
        
        public static void init(string connectionString)
        {
            new DatabaseConnector(connectionString);
        }


    }
}
