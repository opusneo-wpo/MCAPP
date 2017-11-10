using System;
using WorkplaceON.Modules.Login.Models;
using WorkplaceON.Modules.Login.Views;
using Xamarin.Forms;

namespace WorkplaceON.Modules.MainApp.Views
{
    public partial class SettingPage
    {
        LoginItems loginItemsDetails;
        public SettingPage()
        {
            InitializeComponent();
            loginItemsDetails = new LoginItems();
            UserInfo userInfo;
            if (Application.Current.Properties.ContainsKey("userName"))
            {
                var userName = Application.Current.Properties["userName"] as string;
                loginItemsDetails.UserName = userName;
                try
                {
                    userInfo = getUserinfo();
                    //if (userInfo.UserName !=null) {
                    //    loginItemsDetails.UserName = userInfo.UserName;
                    //}
                }
                catch (Exception)
                {
                    
                }
            }
            BindingContext = loginItemsDetails;
        } 

        void onLogoutButtonClick(object sender, EventArgs args)
        {
            App.userDatabaseUtil.deleteAllRecords("UserInfo");
            //App.Current.MainPage = new NavigationPage(new LoginPage());
            Application.Current.Properties.Remove("isFirstTime");
            Navigation.PushAsync(new LoginPage());
        }

        private UserInfo getUserinfo() {
            return App.userDatabaseUtil.GetUserInfo();    
        }

        
    }
}
