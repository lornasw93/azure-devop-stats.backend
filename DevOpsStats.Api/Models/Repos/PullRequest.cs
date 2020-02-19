using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Repos
{
    public class PullRequest
    {
        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("pullRequestId")]
        public string PullRequestId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdBy")]
        public User CreatedBy { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("mergeStatus")]
        public string MergeStatus { get; set; }

        [JsonProperty("mergeId")]
        public string MergeId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("lastMergeSourceCommit")]
        public MergeCommit LastMergeSourceCommit { get; set; }

        [JsonProperty("lastMergeTargetCommit")]
        public MergeCommit LastMergeTargetCommit { get; set; }

        [JsonProperty("lastMergeCommit")]
        public MergeCommit LastMergeCommit { get; set; }

        [JsonProperty("reviewers")]
        public List<Reviewer> Reviewers { get; set; }
    }

    public class Repository
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("project")]
        public Project.Project Project { get; set; }
    }
}
