using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class Log
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
