using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Commit
{
    public class Commit
    {
        [JsonProperty("commitId")]
        public string CommitId { get; set; }

        [JsonProperty("author")]
        public Who Who { get; set; }

        [JsonProperty("committer")]
        public Who Committer { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("changeCounts")]
        public ChangeCounts ChangeCounts { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("remoteUrl")]
        public string RemoteUrl { get; set; }
    } 
}
