
using Newtonsoft.Json;

namespace Core.DTO
{
 public class JsonRequest
    {

    
     [JsonProperty("serviceToken")]
     public ServiceToken serviceToken { get; set; }

     [JsonProperty("model")]
     public ApiModel model { get; set; }

    }

 public class JsonCreate
 {
     [JsonProperty("serviceToken")]
     public ServiceToken serviceToken = new ServiceToken();

     [JsonProperty("model")]
     public ApiModel model = new ApiModel();

 }
}
