using System;
using System.ComponentModel;
using System.Diagnostics;
using WorkplaceON.Modules.Constant;
using WorkplaceON.Modules.Login.Models;
using Xamarin.Forms;

namespace WorkplaceON.Modules.MainApp.Views
{
    public partial class AboutPage
    {
        //private bool isBusy;
        // private WebView webView;
        public AboutPage()
        {
            InitializeComponent();
            //hybridWebView.Uri = "http://biz.workplaceon.com/wpo/app.nsf";
            hybridWebView.Uri = RestUrl.resturl + UserInfo.locationUrl + RestUrl.homePageEndPoint;
            Debug.WriteLine(@" hybridWebView.Uri loading:::" + hybridWebView.Uri);
            hybridWebView.RegisterAction(data => DisplayAlert("Alert", "Hello " + data, "OK"));

            //this.hybridWebView.LoadFinished += (s, e) =>
            //{
            //    this.loaded = true;
            //};

        }

        protected override void OnAppearing()
        {
            Debug.WriteLine(@"News Page :: inside OnAppearing");
        }



        protected override void OnDisappearing()
        {
            Debug.WriteLine(@"News Page :: Inside OnDisappearing");
        }

        private void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            Debug.WriteLine(@"webOnEndNavigating", "Inside webOnEndNavigating");
        }

        private void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            Debug.WriteLine(@"webOnNavigating", "Inside webOnNavigating");
        }


        void backButtonClicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine(@"backButtonClicked", "Inside backButtonClicked");
        }
    }
}
