using System;
using WorkplaceON.Modules.Login.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkplaceON
{
    public partial class WelcomeBackScreen : ContentPage
    {
        public WelcomeBackScreen()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void onWelcomeStartButtonClick(object sender, EventArgs args)
        {
            //App.Current.MainPage = new NavigationPage(new LoginPage());

            Navigation.PushAsync(new EnterPin());
        }
    }
}