using System;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps
{
    public class Basic
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
