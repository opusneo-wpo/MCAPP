using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using WorkplaceON.Data;
using System.IO;
using Xamarin.Forms;
using WorkplaceON.iOS.Data;

[assembly : Dependency (typeof(SQLite_IOS))]

namespace WorkplaceON.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "WorkplaceON.db3";
            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var librarypath = Path.Combine(documentspath, "..", "Library");
            var path = Path.Combine(librarypath, fileName);
            var Connection = new SQLite.SQLiteConnection(path);

            return Connection;
        }

    }
}