using Plugin.Connectivity;
using System;
using System.Diagnostics;
using WorkplaceON.Modules.Constant;
using Xamarin.Forms;

namespace WorkplaceON.Modules.MainApp.Views
{
    public partial class StatusPage
    {
        public StatusPage()
        {
            InitializeComponent();
            activity_indicator.IsVisible = true;
            Debug.WriteLine(@"News Page :: inside OnAppearing");
            statusWebView.Source = "https://baxaui-3aeda.firebaseapp.com/";
            Debug.WriteLine(@"news webviewurl:::" + statusWebView.Source);
        }
        private async void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            activity_indicator.IsVisible = false;
            Debug.WriteLine(@"webOnEndNavigating" + statusWebView.Source);
            Debug.WriteLine(@"webOnEndNavigating" + e.Url);
            if (!CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    var answer = await DisplayAlert("Error", "Network connection not available!!!", "Retry", "Cancel");
                    if (answer)
                    {
                        activity_indicator.IsVisible = true;
                        Debug.WriteLine(@"News Page :: inside OnAppearing");
                        statusWebView.Source = "https://baxaui-3aeda.firebaseapp.com/";
                        Debug.WriteLine(@"news webviewurl:::" + statusWebView.Source);
                    }
                    else
                    {
                        Debug.WriteLine(@"Need to handle other rediretion URL Here:::" + statusWebView.Source);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
        }

        private void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            activity_indicator.IsVisible = true;
            Debug.WriteLine(@"webOnNavigating", "Inside webOnNavigating");
        }

        void backButtonClicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine(@"backButtonClicked", "Inside backButtonClicked");
        }

        protected override void OnAppearing()
        {
           
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine(@"News Page :: Inside OnDisappearing");
        }
    }
}
