using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorkplaceON.Modules.Login.ViewModels;
using WorkplaceON.Modules.Login.Models;
using System.Diagnostics;

namespace WorkplaceON.Modules.Login.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinAuthPage : ContentPage
    {
        public PinAuthPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var vm = new PinAuthViewModel();
            vm.PinViewModel.OnSuccess += (sender, e) =>
            {  
                Navigation.PushAsync(new PinAuthConfirmPage());                
            };
            BindingContext = vm;
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }

    }
}