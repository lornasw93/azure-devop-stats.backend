using System;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Project
{
    public class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public bool IsFavourite { get; set; }
        public int RepoCount { get; set; }
        public int BuildCount { get; set; }
        public int ReleaseCount { get; set; }
     
        public int CompletedPullRequestCount { get; set; }
        public int ActivePullRequestCount { get; set; }
        public int AbandonedPullRequestCount { get; set; }
        public int AllPullRequestCount { get; set; } 
         
        public int BuildInProgressCount { get; set; }
        public int BuildCancelledCount { get; set; }
        public int BuildSucceededCount { get; set; }
        public int BuildFailedCount { get; set; }
        
        public int ReleaseInProgressCount { get; set; }
        public int ReleaseCancelledCount { get; set; }
        public int ReleaseFailedCount { get; set; }
        public int ReleaseSucceededCount { get; set; }
    }
}
