using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceON.Modules.Login.Views;
using Xamarin.Forms;
using Plugin.Connectivity;
using WorkplaceON.Modules.Login.Models;
using System.Net.Http;
using Newtonsoft.Json;
using WorkplaceON.Modules.Constant;

namespace WorkplaceON.Modules.Login.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        private string userName;
        private string password;
        private bool isBusy;
        private bool isError;
        private string errorText;
        private INavigation navigation;
        public Command submitButtonCommand { get; set; }
        private bool isViewEnabled { get; set; }
        private bool flagLoginSuccess { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        ActivityIndicator spinner;

        public LoginPageViewModel()
        {

        }

        public LoginPageViewModel(INavigation inavigation, ActivityIndicator spinnerObj)
        {
            spinner = spinnerObj;
            navigation = inavigation;
            this.IsViewEnabled = true;
            this.UserName = "test1.connect";
            this.Password = "Wengerout123";
            this.submitButtonCommand = new Command(onLogin);
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
                OnPropertyChanged(UserName);

            }

        }

        public bool IsViewEnabled
        {
            get
            {
                return this.isViewEnabled;
            }
            set
            {
                this.isViewEnabled = value;
                OnPropertyChanged("IsViewEnabled");
            }
        }

        public bool IsLoginSuccess
        {
            get
            {
                return this.flagLoginSuccess;
            }
            set
            {
                this.flagLoginSuccess = value;
                OnPropertyChanged("IsLoginSuccess");
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                OnPropertyChanged(Password);
            }
        }

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

        public bool IsError
        {
            get
            {
                return isError;
            }
            set
            {
                isError = value;
                OnPropertyChanged("IsError");
            }
        }

        public string ErrorText
        {
            get
            {
                return errorText;
            }
            set
            {
                errorText = value;
                OnPropertyChanged("ErrorText");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        public void onLogin()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                {
                    try
                    {
                        IsError = false;
                        if (ValidateUserDetails() == true)
                        {
                            ErrorText = "";
                            this.IsBusy = true;
                            this.IsViewEnabled = false;
                            Task.Run(async () =>
                            {
                                UserInfo.CookieContainer = null;
                                var response = await App.WPORestManager.GetLoginData(userName, password);
                                if (response[0].Done)
                                {
                                    Device.BeginInvokeOnMainThread(() =>
                                    {
                                        IsBusy = false;
                                        IsLoginSuccess = true;
                                        navigation.PushAsync(new PinAuthPage());
                                        Application.Current.Properties["userName"] = userName;
                                    });
                                }
                                else {
                                    
                                    Device.BeginInvokeOnMainThread(() =>
                                    {
                                        IsLoginSuccess = false;
                                        IsBusy = false;
                                        App.Current.MainPage.DisplayAlert("Error", "Login failed!", "OK");
                                    });
                                       
                                }
                                
                            });
                                                        
                        }
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
                //ErrorText = "Please Check Your Internet Connection";
            }
        }

        private bool ValidateUserDetails()
        {
            if ((String.IsNullOrEmpty(this.userName)) &&
                (String.IsNullOrEmpty(this.password)))
            {
                IsError = true;
                ErrorText = "* Please enter the appropriate details before you proceed with login";
                return false;
            }
            else if ((String.IsNullOrEmpty(this.userName)))
            {
                IsError = true;
                ErrorText = "* Please enter username to proceed with login";
                return false;
            }
            else if ((String.IsNullOrEmpty(this.password)))
            {
                IsError = true;
                ErrorText = "* Please enter password to proceed with login";
                return false;
            }
            ErrorText = "";
            return true;
        }

        // Following code is added to send reg token to server

        public Regisration GetRegisrationObject()
        {
            Regisration regisration = new Regisration();
            regisration.apiKey = "AAAAmc71FM8:APA91bGhN2xcY5eDQJBIQRH-tFgvFRTiDIUkhplUGyBNauL8O87ow3N5lq1guX-1y2ZrfGFPRYV55Y7-inBpv0Ex54G8T4Pp046eFJUSQaXXrHkaTJ9eveK2nt-WL90VB8zGJFCAnuj9";
            regisration.clientId = 4545454;
            regisration.packageName = "opusNeoTwo";
            regisration.registrationToken = "fFMGVCtMubE:APA91bFqqpHx2YqQWPxm5VSE8lYFqlXYTGz5IrvtViMF6rlAB8sEHFGvNNG0OAWU_cRpwIsONbNfRWRDNNsNCpYE1NecyMH-RYfZ0Vij696cV7mLcDwUKnppS4xQpSJTPZye-HtIrstA";
            regisration.username = "kiranmohare";
            regisration.deviceId = 5646546;
            regisration.group = "fulcrum";
            regisration.platform = "Android";
            return regisration;
        }

        public async Task sendRegistrationTokenToServerAsync(Regisration regisration)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(string.Format(RestUrl.registrationUrl, string.Empty));
                var json = JsonConvert.SerializeObject(regisration);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                System.Diagnostics.Debug.WriteLine($"++++++ json:: {json}");

                HttpResponseMessage response = null;
                if (regisration != null)
                {
                    await client.PostAsync(uri, content);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"++++++ In Exception:: {e.StackTrace}");
            }
        }

    }
}
