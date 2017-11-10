using System.Diagnostics;
using WorkplaceON.Modules.Constant;
using WorkplaceON.Modules.Login.Models;
using Xamarin.Forms;

namespace WorkplaceON.Modules.MainApp.Views
{
    public partial class UpdatePage
    {
        public UpdatePage()
        {
            InitializeComponent();
            //updatesWebView.Source = RestUrl.updatesWebViewUrl;
            //updatesWebView.Source = "http://biz.workplaceon.com/wpo/app.nsf/menuItem.xsp#!mobileupdates";
        }

        private void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            //activity_indicator.IsRunning = false;
            activity_indicator.IsVisible = false;
            Debug.WriteLine(@"webOnEndNavigating", "Inside webOnEndNavigating");
        }

        private void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            //activity_indicator.IsRunning = true;
            activity_indicator.IsVisible = true;
            Debug.WriteLine(@"webOnNavigating", "Inside webOnNavigating");
        }

        void backButtonClicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine(@"backButtonClicked", "Inside backButtonClicked");
        }

        protected override void OnAppearing()
        {
            activity_indicator.IsVisible = true;
            Debug.WriteLine(@"News Page :: inside OnAppearing");
            updatesWebView.Source = RestUrl.updatesWebViewUrl;
            Debug.WriteLine(@"news webviewurl:::" + updatesWebView.Source);
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine(@"News Page :: Inside OnDisappearing");
        }

    }
}
