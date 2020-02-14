using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class Link
    {
        [JsonProperty("badge")]
        public Badge Badge { get; set; }
    }
}
