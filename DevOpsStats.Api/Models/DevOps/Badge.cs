using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps
{
    public class Badge
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
