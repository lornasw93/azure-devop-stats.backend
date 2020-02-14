using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Git.PullRequest
{
    public class PullRequestList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<PullRequest> Value { get; set; }
    }
}
