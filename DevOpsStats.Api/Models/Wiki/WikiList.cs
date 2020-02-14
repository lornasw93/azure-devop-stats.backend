using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Wiki
{
    public class WikiList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<Wiki> Value { get; set; }
    }
}
