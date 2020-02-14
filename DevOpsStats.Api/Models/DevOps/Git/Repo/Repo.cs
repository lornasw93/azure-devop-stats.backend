using System;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Git.Repo
{
    public class Repo
    {
        [JsonRequired, JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("serverUrl")]
        public string ServerUrl { get; set; }   
    }
}
