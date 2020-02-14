using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps
{
    public class Definition
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
