using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class ValueList<T> where T : class
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<T> Value { get; set; }
    }
}
