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
using System.Net.Http;
using System.Net.Http.Headers;
using Org.Apache.Http.Protocol;

namespace WorkplaceON.Droid.Renderers
{
    class MyWebViewClient : WebViewClient
    {
        public override WebResourceResponse ShouldInterceptRequest(WebView view, IWebResourceRequest request)
        {
            //var serverUrl = "https://gateway.mearsgroup.co.uk/mconnect";

            //if (request.Url.ToString().StartsWith(serverUrl))
            //{
                //var client = new HttpClient();
                //var authData = string.Format("{0}:{1}", "test1.connect", "Wengerout123");
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                ////string authorizationValue = "Bearer " + EnvironnementConstant.Token;
                ////client.DefaultRequestHeaders.Add("Authorization", authorizationValue);
                //var result = client.GetAsync(request.Url.ToString()).Result;
                //var encoding = result.Content.Headers.ContentEncoding.GetEnumerator().Current;
                //String contentType = result.Content.Headers.ContentType.ToString();
                //var stream = result.Content.ReadAsStreamAsync().Result;
                //return new WebResourceResponse("text/html", "charset=utf-8", stream);
            //}
            //else
            //{
                //var client = new HttpClient();
                //var authData = string.Format("{0}:{1}", "test1.connect", "Wengerout123");
                //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                //var result = client.GetAsync(request.Url.ToString()).Result;
                //var encoding = result.Content.Headers.ContentEncoding.GetEnumerator().Current;
                //String contentType = result.Content.Headers.ContentType.ToString();
                //var stream = result.Content.ReadAsStreamAsync().Result;
                return base.ShouldInterceptRequest(view, request);
            //}
        }
    }
}