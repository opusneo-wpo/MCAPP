using Newtonsoft.Json;

namespace Core.DTO
{
   public class ApiModel
    {
        [JsonProperty("Name")]
       public string Name { get; set; }
    }

    public class JasonModel
    {
        [JsonProperty("model")]
        public ApiModel apiModel { get; set; }
    }
}
