using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps
{
    public class ListCount
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
