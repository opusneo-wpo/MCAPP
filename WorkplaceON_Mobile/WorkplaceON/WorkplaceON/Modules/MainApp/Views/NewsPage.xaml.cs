using System.Diagnostics;
using WorkplaceON.Modules.Constant;
using WorkplaceON.Modules.Login.Models;
using Xamarin.Forms;

namespace WorkplaceON.Modules.MainApp.Views
{
    public partial class NewsPage
    {
        public NewsPage()
        {
            InitializeComponent();
            //newsWebView.Source = RestUrl.newsWebViewUrl;
            //Debug.WriteLine(@"news webviewurl:::" + newsWebView.Source);
            //newsWebView.Source = "http://biz.workplaceon.com/wpo/app.nsf/menuItem.xsp#!mobilenews";
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
            newsWebView.Source = RestUrl.newsWebViewUrl;
            Debug.WriteLine(@"news webviewurl:::" + newsWebView.Source);
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine(@"News Page :: Inside OnDisappearing");
        }

       
    }
}
