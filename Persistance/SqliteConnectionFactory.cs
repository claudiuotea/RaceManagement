using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class SqliteConnectionFactory
    {
        private SQLiteConnection connection = null;
        private string databaseName;
        public SqliteConnectionFactory(string databaseName)
        {
            this.databaseName = databaseName;
        }

        public SQLiteConnection getConnection()
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed)
            {
                connection = getNewConnection();
                connection.Open();
            }
            return connection;
        }
        /*
        private string getConnectionStringByName()
        {
            string returnValue = null;
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[databaseName];
            //string databasePath = ConfigurationManager.AppSettings["database"];
            if (databasePath != null)
                returnValue = databasePath;
            return returnValue;
        }
        */
        private SQLiteConnection getNewConnection()
        {
            //var connectionString = @"data source=E:\Anul2\Semestrul2\Medii de proiectare si programare\Java GRPC\src\main\resources\SQLite\database.db";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            var connectionString= "Data Source=|DataDirectory|\\database.db";
            var conn = new SQLiteConnection(connectionString);
            return conn;
        }
    }
}
