
 // Author    : Fulcrum World Wide                                                        
// Created   : 27-11-2015                                                                  
// Purpose   : Generic API service which can accept any type of jason parameter ,process this parameters depending on the runtime type passed                                                 
//             & make a service call at any configured endPoint & return a jason .                                                                                                                                                                  
// Change Log:                                                                           
// ===========                                                                           
// Name           Date                                                           
// Jess Joseph    27-11-2015      

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using ModernHttpClient;
using Newtonsoft.Json;

namespace Core.Services
{
    public class CommonApiClient
    {
        #region Constants

        private const string WBC_URL = "https://192.168.41.141/api/";
        private const string LOCALE = "en-us";
        private const string SEARCH = "/search";
        private const string DELETE = "/delete";
        private const string UPDATE = "/update";
        private readonly string URL;

        #endregion 

        #region Constructors

        public CommonApiClient()
        {
            URL = WBC_URL;
        }

        public CommonApiClient(string url)
        {
            URL = url;
        }

        #endregion

        #region Authenticate

        public async Task<string> Authenticate<T>(string jsonRequest, T contentRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = ConvertToJson(contentRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PostAsync(URL + jModel.apiModel.Name, httpStringContent).Result)
                    {
                        // response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion

        #region Get API

        public async Task<string> GetSearch(string jsonRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);

                if (jModel.apiModel != null)
                {
                    using (var response = client.GetAsync(URL + jModel.apiModel.Name + SEARCH).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

       

        public async Task<string> Get(string jsonRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);

                if (jModel.apiModel != null)
                {
                    using (var response = client.GetAsync(URL + jModel.apiModel.Name).Result)                                                    
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion      

        #region POST API

        public async Task<string> Add<T>(string jsonRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = JasonContentDeserialize<T>(jsonRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PostAsync(URL + jModel.apiModel.Name, httpStringContent).Result)                                                    
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        public async Task<string> Post<T>(string jsonRequest, T contentRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = ConvertToJson(contentRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PostAsync(URL + jModel.apiModel.Name, httpStringContent).Result)
                    {
                        response.EnsureSuccessStatusCode();                       
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion        

        #region Delete API

        public async Task<string> DeletePost<T>(string jsonRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = JasonContentDeserialize<T>(jsonRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PostAsync(URL + jModel.apiModel.Name + DELETE, httpStringContent).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        public async Task<string> Delete(string jsonRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);

                if (jModel.apiModel != null)
                {
                    using (var response = client.DeleteAsync(URL + jModel.apiModel.Name).Result)                                                   
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion

        #region Update API

        public async Task<string> UpdatePost<T>(string jsonRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = JasonContentDeserialize<T>(jsonRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PostAsync(URL + jModel.apiModel.Name + UPDATE, httpStringContent).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion

        #region Put API

        public async Task<string> PutUpdate<T>(string jsonRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = JasonContentDeserialize<T>(jsonRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PutAsync(URL + jModel.apiModel.Name, httpStringContent).Result)                                                    
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion
      
        #region Sync Push

        public async Task<string> SyncPush<T>(string jsonRequest, T contentRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = ConvertToJson(contentRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PostAsync(URL + jModel.apiModel.Name, httpStringContent).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion

        #region Sync Pull

        public async Task<string> SyncPull<T>(string jsonRequest, T contentRequest)
        {
            using (var client = new HttpClient(new NativeMessageHandler(false, true)))
            {
                var jModel = JasonDeserialize(jsonRequest, client);
                var httpStringContent = ConvertToJson(contentRequest);

                if (jModel.apiModel != null)
                {
                    using (var response = client.PostAsync(URL + jModel.apiModel.Name, httpStringContent).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                throw new NullReferenceException("jsonRequest.model");
            }
        }

        #endregion

        #region Comman private methods

        private JasonModel JasonDeserialize(string jsonRequest, HttpClient client)
        {
            var serviceToken = JsonConvert.DeserializeObject<JasonServiceToken>(jsonRequest);

            DefaultRequestHeader(client, serviceToken.serviceToken);

            var jModel = JsonConvert.DeserializeObject<JasonModel>(jsonRequest); 

            return jModel;
        }

        private static StringContent JasonContentDeserialize<T>(string jsonRequest)
        {
            var requestContent = JsonConvert.DeserializeObject<T>(jsonRequest);
            return new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json");                            
        }

        private static StringContent ConvertToJson<T>(T contentRequest)
        {
            return new StringContent(JsonConvert.SerializeObject(contentRequest), Encoding.UTF8, "application/json");               
        } 

        private void DefaultRequestHeader(HttpClient client, ServiceToken serviceToken)
        {
            if (serviceToken == null) throw new ArgumentNullException("serviceToken");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Id", serviceToken.UserId.ToString());
            client.DefaultRequestHeaders.Add("Client-Token", serviceToken.TenantKey);
            client.DefaultRequestHeaders.Add("Access-Token", serviceToken.AccessToken);
            client.DefaultRequestHeaders.Add("WebAccess-Token", serviceToken.TokenKey);
            client.DefaultRequestHeaders.Add("WebAccess-TokenId", serviceToken.TokenId);
            client.DefaultRequestHeaders.Add("Access-Application", serviceToken.ApplicationKey);
            client.DefaultRequestHeaders.Add("Locale", LOCALE);
            client.DefaultRequestHeaders.Add("ApplicationTenantLinkId", serviceToken.ApplicationTenantLinkId.ToString());
            client.DefaultRequestHeaders.Add("UserName", serviceToken.UserName);
            client.DefaultRequestHeaders.Add("FirstName", serviceToken.FirstName);
            client.DefaultRequestHeaders.Add("LastName", serviceToken.LastName);
            client.DefaultRequestHeaders.Add("Email", serviceToken.Email);
        }

        #endregion
    }
}