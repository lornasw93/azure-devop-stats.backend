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
         
        public int RepoCount { get; set; } 

        public PullRequestCounts PullRequestCounts { get; set; }
        public BuildCounts BuildCounts { get; set; }
        public DeploymentCounts DeploymentCounts { get; set; }

        public int TestRunCount { get; set; }
        public int TestPlanCount { get; set; }

        public int TeamCount { get; set; }

        [JsonProperty("defaultTeam")]
        public Basic DefaultTeam { get; set; }
    }
      
    public class PullRequestCounts
    {
        public int CompletedPullRequestCount { get; set; }
        public int ActivePullRequestCount { get; set; }
        public int AbandonedPullRequestCount { get; set; } 
        public int NotSetCount { get; set; }
         
        public  int Approved { get; set; }
        public  int ApprovedWithSuggestions { get; set; }
        public  int NoVote { get; set; }
        public  int WaitingForAuthor { get; set; }
        public  int Rejected { get; set; } 
    }

    public class BuildCounts
    {
        public int BuildInProgressCount { get; set; }
        public int BuildCancelledCount { get; set; }
        public int BuildSucceededCount { get; set; }
        public int BuildFailedCount { get; set; }
    }

    public class DeploymentCounts
    {
        public int InProgressCount { get; set; }
        public int NotDeployedCount { get; set; }
        public int FailedCount { get; set; }
        public int SucceededCount { get; set; }
    }
}
