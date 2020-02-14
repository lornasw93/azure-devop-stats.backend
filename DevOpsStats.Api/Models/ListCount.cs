using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class ListCount
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
