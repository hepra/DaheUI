using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFrameworkCore.Settings;

namespace UIFrameworkCore.Helper
{
    public class SqliteHelper
    {
        static public string dbPath { get; set; }
        static private SQLiteConnection _DbContext = null;
        public static SQLiteConnection GetDbContext()
        {
            if (_DbContext == null)
            {
                _DbContext = new SQLiteConnection(SettingManager.GetSettingSingleton().DbPath);
            }
            return _DbContext;
        }
        static public bool CreateTable<T>()
        {
            var res = GetDbContext().CreateTable<T>();
            if (res == CreateTableResult.Created)
            {
                return true;
            }
            return false;
        }
        public static int Insert<T>(T data)
        {
            return GetDbContext().Insert(data);
        }
        public static int InsertList<T>(List<T> data)
        {
            return GetDbContext().InsertAll(data);
        }
        public static int Update<T>(T data)
        {
            return GetDbContext().Update(data);
        }

        public static int Delete<T>(T data)
        {
            return GetDbContext().Delete(data);
        }
    }
}
