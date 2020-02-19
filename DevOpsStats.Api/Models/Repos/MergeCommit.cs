using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Repos
{
    public class MergeCommit
    {
        [JsonProperty("commitId")]
        public string CommitId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }
}
