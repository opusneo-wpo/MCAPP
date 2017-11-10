using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorkplaceON.Droid
{
    [Activity(Label = "WorkplaceON", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true, Theme = "@style/splashTheme")]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //base.SetContentView();
            StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}