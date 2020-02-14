using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Release
{
    public class ReleaseList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<Release> Value { get; set; }
    }
}
