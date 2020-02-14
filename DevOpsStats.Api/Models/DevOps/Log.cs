using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps
{
    public class Log
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
