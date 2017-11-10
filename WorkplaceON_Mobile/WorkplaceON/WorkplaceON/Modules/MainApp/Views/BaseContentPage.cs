using Xamarin.Forms;

namespace WorkplaceON.Modules.MainApp.Views
{
    public class BaseContentPage : ContentPage
    {
        public void SendAppearing()
        {
            OnAppearing();
        }

        public void SendDisappearing()
        {
            OnDisappearing();
        }
    }
}