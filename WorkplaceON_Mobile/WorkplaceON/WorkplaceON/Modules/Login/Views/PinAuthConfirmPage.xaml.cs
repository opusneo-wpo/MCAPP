using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceON.Modules.Login.ViewModels;
using Xamarin.Forms;
using WorkplaceON.Modules.MainApp.Views;
using Xamarin.Forms.Xaml;
using WorkplaceON.Modules.Login.Models;
using WorkplaceON.Modules.Services;
using WorkplaceON.Modules.AES;
using WorkplaceON.Modules.Constant;

namespace WorkplaceON.Modules.Login.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinAuthConfirmPage : ContentPage
    {
        public PinAuthConfirmPage()
        {

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var vm = new ConfirmPinAuthViewModel();
            UserInfo userInfo;
            vm.PinViewModel.OnError += (sender, e) =>
            {
                ShowWrongPinCode();
            };

            vm.PinViewModel.OnSuccess += (sender, e) =>
            {
                Application.Current.Properties["isFirstTime"] = "NO";
                Application.Current.Properties["isCookieSetRequired"] = "YES";
                Navigation.PushAsync(new MainPage());
                userInfo = new UserInfo();
                var deviceId = DependencyService.Get<IDevice>().GetIdentifier();
                userInfo.PIN = Application.Current.Properties["CreatePIN"] as string;
                userInfo.UserName = Application.Current.Properties["userName"] as string;
                userInfo.AuthToken = Application.Current.Properties["authT"] as string;
                userInfo.DeviceId = deviceId;
                if (userInfo.UserName !=null) {
                    saveUserInfoDb(userInfo);
                }
                // Delete saved properties
                removeProperties();
            };

            BindingContext = vm;
        }

        private void ShowWrongPinCode()
        {
            DisplayAlert("Error", "Please enter correct pin", "Ok");
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private void saveUserInfoDb(UserInfo userInfo) {
            // Apply encryption before saving values in Db              
            userInfo = encryptMyUserInfo(userInfo);
            App.userDatabaseUtil.SaveUserInfo(userInfo);
        }

        private void removeProperties() {
            Application.Current.Properties.Remove("CreatePIN");
            //Application.Current.Properties.Remove("userName");
            Application.Current.Properties.Remove("authT");
        }

        private UserInfo encryptMyUserInfo(UserInfo userInfo) {            
            userInfo.UserName = Convert.ToBase64String(Crypto.EncryptAes(userInfo.UserName, RestUrl.keyGenerationPassword));
            userInfo.PIN = Convert.ToBase64String(Crypto.EncryptAes(userInfo.PIN, RestUrl.keyGenerationPassword));
            return userInfo;
        }
    }
}