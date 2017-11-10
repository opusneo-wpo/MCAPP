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
using Android.Webkit;

namespace WorkplaceON.Droid.Renderers
{
    class FileChooserWebClient : WebChromeClient
    {
        private Action<IValueCallback, Java.Lang.String, Java.Lang.String> callback;

        public FileChooserWebClient(Action<IValueCallback, Java.Lang.String, Java.Lang.String> callback)
        {
            callback = callback;
        }

        // For Android < 5.0
        [Java.Interop.Export]
        public void openFileChooser(IValueCallback uploadMsg, Java.Lang.String acceptType, Java.Lang.String capture)
        {
            callback(uploadMsg, acceptType, capture);
        }

        // For Android > 5.0
        public override Boolean OnShowFileChooser(Android.Webkit.WebView webView, IValueCallback uploadMsg, WebChromeClient.FileChooserParams fileChooserParams)
        {
            try
            {
                callback(uploadMsg, null, null);
            }
            catch (Exception)
            {

            }
            return true;
        }
    }
}