using WorkplaceON.Modules.Login.Models;
using WorkplaceON.Modules.Login.ViewModels;
using WorkplaceON.Modules.MainApp.Views;
using WorkplaceON.Modules.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkplaceON.Modules.Login.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterPin : ContentPage
    {
        public static WorkplaceONRestManager WPORestManager { get; private set; }
        public EnterPin()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var vm = new EnterPinViewModel();
            var myAuthToken  = getAuthTokenDb();
            if(myAuthToken != null)
            {
                WPORestManager = new WorkplaceONRestManager(new RestService(myAuthToken));
            }
            
            vm.PinViewModel.OnSuccess += (sender, e) =>
            {
                Application.Current.Properties["isCookieSetRequired"] = "YES";
                EnterPinViewModel enterPinViewModel = new EnterPinViewModel();
                // calling login API with stored authToken
                enterPinViewModel.loginOnEnterPIN(myAuthToken);                
                
            };

            vm.PinViewModel.OnError += (sender, e) =>
            {
                DisplayAlert("Error!!", "Please enter correct PIN", "OK");
            };

            BindingContext = vm;
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private string getAuthTokenDb() {

            UserInfo userInfo = App.userDatabaseUtil.GetUserInfo();
            if (userInfo != null)
            {
                return userInfo.AuthToken;
            }
            else {
                return null;
            }
            
        }
    }
}