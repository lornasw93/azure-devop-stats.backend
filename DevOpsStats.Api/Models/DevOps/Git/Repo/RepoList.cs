using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Git.Repo
{
    public class RepoList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<Repo> Value { get; set; }
    }
}
