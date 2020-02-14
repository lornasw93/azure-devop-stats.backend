using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps
{
    public class Link
    {
        [JsonProperty("badge")]
        public Badge Badge { get; set; }
    }
}
