using System;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Wiki
{
    public class Wiki
    {
        public Basic Basic { get; set; }

        [JsonProperty("id")]
        public string RemoteUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("repositoryId")]
        public Guid RepositoryId { get; set; }
    }
}
