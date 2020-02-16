using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class ListObject
    {
        [JsonProperty("value")]
        public object List { get; set; }
    }
}
