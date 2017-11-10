using FormsPinView.PCL;
using Plugin.Connectivity;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WorkplaceON.Modules.AES;
using WorkplaceON.Modules.Constant;
using WorkplaceON.Modules.Login.Models;
using WorkplaceON.Modules.MainApp.Views;
using Xamarin.Forms;

namespace WorkplaceON.Modules.Login.ViewModels
{
    class EnterPinViewModel
    {

        //private static readonly char[] s_pin = new[] { '1', '2', '3', '4' };
        public event PropertyChangedEventHandler PropertyChanged;        
        private bool isBusy = false;
        ActivityIndicator spinner;
        public EnterPinViewModel(ActivityIndicator spinnerObj) {
            spinner = spinnerObj;
        }
        public EnterPinViewModel()
        {
           
        }

        public PinViewModel PinViewModel { get; private set; } = new PinViewModel
        {
            TargetPinLength = 4,
            ValidatorFunc = (arg) =>
            {
                string savedPIN = getPINForUser();
                char[] s_pin = (savedPIN).ToCharArray();                
                return arg.SequenceEqual(s_pin);
            }
        };
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        private static string getPINForUser() {
            UserInfo userInfo = App.userDatabaseUtil.GetUserInfo();
            if (userInfo != null)
            {
                byte[] encryptedPINBytes = Convert.FromBase64String(userInfo.PIN);
                string myOrinalPIN = Crypto.DecryptAes(encryptedPINBytes, RestUrl.keyGenerationPassword);
                return myOrinalPIN;
            }
            else {
                return null;
            }
            
        }
        public void loginOnEnterPIN(string myAuthToken)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                {
                    try
                    {   
                        this.IsBusy = true;                            
                        Task.Run(async () =>
                        {
                            UserInfo.CookieContainer = null;
                            var response = await App.WPORestManager.EnterPINLoginDataAsync(myAuthToken);
                            if (response[0].Done)
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    IsBusy = false;
                                    App.Current.MainPage = new NavigationPage(new MainPage());
                                });
                                
                            }
                            else
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    IsBusy = false;
                                    App.Current.MainPage.DisplayAlert("Error!", "Login failed, Please try again", "OK");
                                });
                                
                            }

                        });
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please Check Your Internet Connection", "OK");
            }
        }
    }
}
