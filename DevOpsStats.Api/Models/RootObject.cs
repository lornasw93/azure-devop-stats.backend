using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class RootObject
    {
        [JsonProperty("value")]
        public object List { get; set; }
    } 
}
