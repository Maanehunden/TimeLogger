using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Timelogger.Data.Migrations;


namespace Timelogger.Data.Repositories
{
    public static class DatabaseInitializer
    {
        public static void Initialize(string databaseName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(baseDirectory, $"{databaseName}.db");

            if (!File.Exists(dbPath))
            {
                CreateDatabase(databaseName, dbPath);
            }
        }

        private static void CreateDatabase(string databaseName, string dbPath)
        {
            SQLiteConnection.CreateFile(dbPath);

            using (var connection = new SQLiteConnection($"Data Source={databaseName}.db"))
            {
                connection.Open();

                using (var createTable = new SQLiteCommand(MigrationsCommands.InitCreate, connection))
                {
                    createTable.ExecuteNonQuery();
                }
            }
        }
    }
}
