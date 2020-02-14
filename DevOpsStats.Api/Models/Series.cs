using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class Series
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
