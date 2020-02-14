using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Iteration
{
    public class IterationList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<Iteration> Value { get; set; }
    }
}
