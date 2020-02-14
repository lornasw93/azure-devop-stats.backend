using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Release
{
    public class Release
    {
        [JsonRequired, JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
         
        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("createdBy")]
        public User CreatedBy { get; set; }

        [JsonProperty("variables")]
        public object Variables { get; set; }

        [JsonProperty("environments")]
        public List<Environment> Environments { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
