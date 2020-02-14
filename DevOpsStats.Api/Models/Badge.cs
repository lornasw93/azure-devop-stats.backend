using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class Badge
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
