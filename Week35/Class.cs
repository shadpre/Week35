using Dapper;
using Npgsql;
namespace Week35
{
    public class DatabaseConnector
    {
        private static DatabaseConnector _instance;
        private static string _connectionString;

        private DatabaseConnector(string connectionString) {
            _connectionString = connectionString;
        }

        public static DatabaseConnector getInstance()
        {
            if (_instance == null) { throw new Exception("You must Init"); }
            return _instance;
        }
        
        public static void init(string connectionString)
        {
            _instance = new DatabaseConnector(connectionString);
        }
    }
}
