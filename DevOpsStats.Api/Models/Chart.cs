using System.Collections.Generic; 
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class Chart
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("series")]
        public IEnumerable<Series> Series { get; set; }
    }

    public class Series
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
