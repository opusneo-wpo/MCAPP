using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkplaceON.Modules.Login.Views;
using WorkplaceON.Modules.MainApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkplaceON
{
     public partial class StartScreen : ContentPage
    {
        public StartScreen()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
  
        void onStartButtonClick(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());

            //Navigation.PushAsync(new EnterPin());
        }
    }
}