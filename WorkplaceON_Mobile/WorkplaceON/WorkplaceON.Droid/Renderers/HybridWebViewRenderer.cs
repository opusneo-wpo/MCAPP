using Android.Webkit;
using WorkplaceON.Droid.Renderers;
using WorkplaceON.Modules.MainApp.CustomRenderer;
using WorkplaceON.Modules.Login.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace WorkplaceON.Droid.Renderers
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, Android.Webkit.WebView>
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";

        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var webView = new Android.Webkit.WebView(Forms.Context);
                webView.Settings.JavaScriptEnabled = true;
                SetNativeControl(webView);
            }
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            {
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
                var cookieManager = CookieManager.Instance;
                cookieManager.SetAcceptCookie(true);
                cookieManager.RemoveAllCookie();
                var cookies = UserInfo.CookieContainer.GetCookies(new System.Uri(string.Format("https://gateway.mearsgroup.co.uk/mconnect", string.Empty)));
                for (var i = 0; i < cookies.Count; i++)
                {
                    string cookieValue = cookies[i].Value;
                    string cookieDomain = cookies[i].Domain;
                    string cookieName = cookies[i].Name;
                    cookieManager.SetCookie(cookieDomain, cookieName + "=" + cookieValue);
                }
                //cookieManager.SetCookie("gateway.mearsgroup.co.uk", "LastMRH_Session" + "=" + "341a3fe3");
                //cookieManager.SetCookie("gateway.mearsgroup.co.uk", "MRHSession " + "=" + "d6864b3945471b288c3f5d66341a3fe3");
                //cookieManager.SetCookie("connect.mearsgroup.co.uk", "LtpaToken" + "=" + "AAECAzU5RkFGOTE2NTlGQkExRDZDTj10ZXN0MSBjb25uZWN0L089VGVzdMRjuyREezJdstxoCmbGqFfsJztl");
                //cookieManager.SetCookie("connect.mearsgroup.co.uk", "SessionID" + "=" + "9CA6907E401F99AAD8BBD7C693F767FBAB30B177");
                //cookieManager.SetCookie("biz.workplaceon.com", "LtpaToken" + "=" + "AAECAzU5RkFDNjY1NTlGQjM2RTVDTj1TYW5kcmEgRGFzaC9PVT1UZXN0L089T3B1c05lb36QngnZxWEdZn4Q3xDJdX0X4Blm");
                //cookieManager.SetCookie("biz.workplaceon.com", "SessionID" + "=" + "8FFB39B7E37026CE8C64BC00797D82FC762471D8");
                Control.SetWebViewClient(new MyWebViewClient());
                Control.LoadUrl(string.Format(Element.Uri));
                //InjectJS(JavaScriptFunction);
            }
        }

        void InjectJS(string script)
        {
            if (Control != null)
            {
                Control.LoadUrl(string.Format("javascript: {0}", script));
            }
        }
    }
}