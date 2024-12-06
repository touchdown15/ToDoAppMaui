using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOApp.Database.Config
{
    public static class Constants
    {
        public const string DatabaseFilename = "ToDoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(path, DatabaseFilename);
            }
        }
    }
}
