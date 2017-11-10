using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Core.DTO;
using ModernHttpClient;

namespace Core.Services
{
    public class InventoryCheckProduct : Base
    { 
          string accessToken = string.Empty;

         public InventoryCheckProduct(string access)
        {
            accessToken = access;
        }

         #region SearchInventoryCheckProduct

         public async Task<string> SearchInventoryCheckProduct()
         {
             using (var client = new HttpClient(new NativeMessageHandler(false, true)))
             {
                 DefaultRequestHeader(client);

                 var req = PrepareSearchInventoryCheckProductP();

                 var httpStringContent = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8,
                     "application/json");

                 using (
                     HttpResponseMessage response =
                         client.PostAsync(URL + "inventoryCheckProduct/search", httpStringContent).Result)
                 {
                     response.EnsureSuccessStatusCode();

                     return await response.Content.ReadAsStringAsync();
                 }
             }
         }



         public InventoryCheckProductDTO PrepareSearchInventoryCheckProductP()
         {
             InventoryCheckProductDTO inventoryCheckP = new InventoryCheckProductDTO
             {
                 serviceToken = null,
                 RCache = 0,
                 PageNumber = 1,
                 PageSize = 10,
                 Limit = 0,
                 Include = string.Empty,
                 Select = string.Empty,
                 Relations = string.Empty
             };

             return inventoryCheckP;
         }

         #endregion

         public void DefaultRequestHeader(HttpClient client)
         {
             client.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
             client.DefaultRequestHeaders.Add("User-Id", "1");
             client.DefaultRequestHeaders.Add("Client-Token", "9839F47F-5EB7-4A4D-B90F-AF2D6C52DB06");
             client.DefaultRequestHeaders.Add("Access-Token", accessToken);
             client.DefaultRequestHeaders.Add("WebAccess-Token", "A922600A-4393-4E8A-8D91-03EA8C8F2C20");
             client.DefaultRequestHeaders.Add("WebAccess-TokenId", "E3AFE158-FDFA-42C7-9A9D-011ADE4B69CF");
             client.DefaultRequestHeaders.Add("Access-Application", "AA01F670-2451-43EA-B660-B753143BDE99");
             client.DefaultRequestHeaders.Add("Locale", "en-us");
             client.DefaultRequestHeaders.Add("ApplicationTenantLinkId", "1");
             client.DefaultRequestHeaders.Add("UserName", "ramesh_devadkar@fulcrumww.com");
             client.DefaultRequestHeaders.Add("FirstName", "Ramesh");
             client.DefaultRequestHeaders.Add("LastName", "Devadkar");
             client.DefaultRequestHeaders.Add("Email", "ramesh_devadkar@fulcrumww.com");
         }
    }
}
