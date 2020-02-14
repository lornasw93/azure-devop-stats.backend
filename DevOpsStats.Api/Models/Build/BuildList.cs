using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Build
{
    public class BuildList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<Build> Value { get; set; }
    }
}
