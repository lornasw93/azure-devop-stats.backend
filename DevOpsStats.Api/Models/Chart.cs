using System.Collections.Generic;
using System.Linq;
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
}
