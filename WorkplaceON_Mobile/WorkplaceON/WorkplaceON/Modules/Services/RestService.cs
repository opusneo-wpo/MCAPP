using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using WorkplaceON.Modules.Login.Models;
using System.ComponentModel;
using WorkplaceON.Modules.Login.ViewModels;
using WorkplaceON.Modules.Constant;

using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace WorkplaceON.Modules.Services
{
    class RestService : IRestService
    {
      
        LoginPageViewModel logindetails;
        public List<LoginItems> Items { get; private set; }
        public RestService()
        {
        }
        public RestService(string authToken) {
          }
        public async Task<List<LoginItems>> LoginDataAsync(string UserName,string PassWord)
        {
            UserInfo.CookieContainer = null;
            HttpClient client = null;
            HttpClientHandler handler = null;
            logindetails = new LoginPageViewModel();
            var authData = string.Format("{0}:{1}", UserName, PassWord);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            Application.Current.Properties["authT"] = authHeaderValue;

            handler = new HttpClientHandler { CookieContainer = UserInfo.CookieContainer };
            //handler.AllowAutoRedirect = false;
            handler.MaxAutomaticRedirections = 1;

            client = new HttpClient(handler)
            {
                MaxResponseContentBufferSize = 256000
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);//dGVzdDEuY29ubmVjdDpXZW5nZXJvdXQxMjM=
            var cookieContainer = new CookieContainer();
            LoginItems loginData = new LoginItems();
            List<LoginItems> itemList = new List<LoginItems>();
            var loginAPI = new Uri(string.Format(RestUrl.resturl, string.Empty));
            var uri = new Uri(string.Format(RestUrl.resturl, string.Empty));
            try
            {
                var response = await client.GetAsync(loginAPI);
                UserInfo.CookieContainer = handler.CookieContainer;
                var cookies = UserInfo.CookieContainer.GetCookies(new Uri(string.Format(RestUrl.resturl, string.Empty)));
                if ((int)response.StatusCode == 302)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var headers = response.Headers.Concat(response.Content.Headers);
                    Debug.WriteLine(@"content ", response);
                    Debug.WriteLine(@"headers ", headers);
                    IEnumerable<string> headerValues = response.Headers.GetValues("Location");
                    UserInfo.locationUrl = response.Headers.FirstOrDefault(x => x.Key == "Location").Value?.FirstOrDefault();
                    Debug.WriteLine(@"location ::" + UserInfo.locationUrl);
                    if (UserInfo.locationUrl.Equals(RestUrl.myPolicyRedirectUrl))
                    {
                        loginData.Done = false;
                        itemList.Add(loginData);
                        // Items = JsonConvert.DeserializeObject<List<LoginItems>>(content);
                    }
                    else
                    {
                        loginData.Done = true;
                        itemList.Add(loginData);
                    }
                }
                else {
                    loginData.Done = false;
                    itemList.Add(loginData);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                loginData.Done = false;
                itemList.Add(loginData);
            }
            return itemList;
        }

        public async Task<List<LoginItems>> EnterPINLoginDataAsync(string authToken) {
            UserInfo.CookieContainer = null;
            HttpClient client = null;
            HttpClientHandler handler = null;
            Debug.WriteLine(@"authToken ::" + authToken);
            handler = new HttpClientHandler { CookieContainer = UserInfo.CookieContainer };
            //handler.AllowAutoRedirect = false;
            handler.MaxAutomaticRedirections = 1;
            client = new HttpClient(handler)
            {
                MaxResponseContentBufferSize = 256000
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            var loginAPI = new Uri(string.Format(RestUrl.resturl, string.Empty));
            LoginItems lo = new LoginItems();
            List < LoginItems > itemList = new List<LoginItems>();
            try
            {
                var response = await client.GetAsync(loginAPI);
                UserInfo.CookieContainer = handler.CookieContainer;
                var cookies = UserInfo.CookieContainer.GetCookies(new Uri(string.Format(RestUrl.resturl, string.Empty)));
                var headers = response.Headers.Concat(response.Content.Headers);
                Debug.WriteLine(@"content ", response);
                Debug.WriteLine(@"headers ", headers);
                IEnumerable<string> headerValues = response.Headers.GetValues("Location");
                UserInfo.locationUrl = response.Headers.FirstOrDefault(x => x.Key == "Location").Value?.FirstOrDefault();
                Debug.WriteLine(@"location ::" + UserInfo.locationUrl);
                if ((int)response.StatusCode == 302)
                {
                    if (UserInfo.locationUrl.Equals(RestUrl.myPolicyRedirectUrl))
                    {
                        lo.Done = false;
                        itemList.Add(lo);
                        // Items = JsonConvert.DeserializeObject<List<LoginItems>>(content);
                    }
                    else
                    {
                        lo.Done = true;
                        itemList.Add(lo);
                    }
                }
                else
                {
                    lo.Done = false;
                    itemList.Add(lo);
                }
            }
            catch(Exception ex) {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                lo.Done = false;
                itemList.Add(lo);
            }
            
            return itemList;
        }
    }
}
