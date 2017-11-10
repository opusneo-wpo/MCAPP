using WorkplaceON.Data;
using System.IO;
using Xamarin.Forms;
using WorkplaceON.Droid.Data;
using WorkplaceON.Modules.Services;

[assembly: Dependency(typeof(SQLite_Android))]

namespace WorkplaceON.Droid.Data
{
    public class SQLite_Android : ISQLite,IDevice
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqlitefilename = "WorkplaceON.db3";
            string documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, sqlitefilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

        public string GetIdentifier()
        {
            //return Settings.Secure.GetString(Forms.Context.ContentResolver, Settings.Secure.AndroidId);
            return Android.Provider.Settings.Secure.GetString(Forms.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
        }
    }
}