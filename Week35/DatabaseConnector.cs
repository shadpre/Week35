using Dapper;
using Npgsql;

namespace Week35
{
    public class DatabaseConnector
    {
        private static DatabaseConnector _instance;

        public  NpgsqlConnection con { get; }
        public string ConnectionString { get; }

        private DatabaseConnector()
        {
            ConnectionString = GetConfiguration().GetConnectionString("myDb1");
            con = new NpgsqlConnection(GetConfiguration().GetConnectionString("myDb1"));
        }

        private static void Init()
        {
            _instance = new DatabaseConnector();
            
        }

        public static DatabaseConnector GetInstance() 
        { 
            if(_instance == null) Init();
            return _instance;
        }

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}