using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using WorkplaceON.Modules.Login.Models;
using System.Diagnostics;

namespace WorkplaceON.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {            
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<UserInfo>();
            Debug.WriteLine("DB::", "Table created....");
        }

        public UserInfo GetUserInfo() {
            lock (locker) {
                if (database.Table<UserInfo>().Count() == 0)
                {
                    return null;
                }
                else {                    
                    return database.Table<UserInfo>().First();
                }
            }
        }
        public int SaveUserInfo(UserInfo aUserInfo)
        {
            lock (locker)
            {
                UserInfo mUserInfo;                
                mUserInfo = GetUserInfo();
                if (mUserInfo != null && mUserInfo.UserName !=null) {                    
                    return database.Update(aUserInfo);
                }
                else {
                    return database.Insert(aUserInfo);
                }
                
            }

        }

        public void ExecuteQuery(string query, object[] args)
        {
            lock (locker)
            {
                database.Execute(query, args);
            }
        }
        public List<T> Query<T>(string query, object[] args) where T : new()
        {
            lock (locker)
            {
                return database.Query<T>(query, args);
            }
        }

        public void deleteAllRecords(string tableName) {
            lock (locker)
            {
                database.Execute("DELETE FROM "+tableName);
            }
        }
    }
}
