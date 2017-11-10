using WorkplaceON.Modules.Login.Models;
using WorkplaceON.Modules.Login.ViewModels;
using Xamarin.Forms;


namespace WorkplaceON.Modules.Login.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ActivityIndicator spinner = this.FindByName<ActivityIndicator>("activityIndicator");
            BindingContext = new LoginPageViewModel(this.Navigation, spinner);            
        }

        protected  override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");
                if (result) await this.Navigation.PopAsync(); 
            });

            return true;
        }
    }
}