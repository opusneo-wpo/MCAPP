﻿using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using Plugin.FirebasePushNotification;
using System.Collections.Generic;
using WorkplaceON.Droid.PushNotification;

namespace WorkplaceON.Droid
{
    //You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            FirebasePushNotificationManager.Initialize(this, true);
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("Received");
                    if (p.Data.ContainsKey("body"))
                    {
                        string message = p.Data["body"];
                        System.Diagnostics.Debug.WriteLine("Push Message Body:: " + message);
                    }
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    MyNotificationHandler myNotificationHandler = new MyNotificationHandler();
                    parameters.Add("body", p.Data["body"]);
                    myNotificationHandler.onMessageReceived(parameters);
                    //OnNotificationReceived(parameters);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception", ex);
                }

            };

            //A great place to initialize Xamarin.Insights and Dependency Services!
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}