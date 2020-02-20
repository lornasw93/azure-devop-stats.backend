using System; 
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Boards.WorkItem
{
    public class Fields
    {
        [JsonProperty("areaPath")]
        public string AreaPath { get; set; }

        [JsonProperty("teamProject")]
        public string TeamProject { get; set; }

        [JsonProperty("iterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty("workItemType")]
        public string WorkItemType { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("assignedTo")]
        public WhoBy AssignedTo { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("createdBy")]
        public WhoBy CreatedBy { get; set; }

        [JsonProperty("changedDate")]
        public DateTime ChangedDate { get; set; }

        [JsonProperty("changedBy")]
        public WhoBy ChangedBy { get; set; }

        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("closedDate")]
        public DateTime ClosedDate { get; set; }

        [JsonProperty("closedBy")]
        public WhoBy ClosedBy { get; set; }

        [JsonProperty("stateChangeDate")]
        public DateTime StateChangeDate { get; set; }

        [JsonProperty("activatedDate")]
        public DateTime ActivatedDate { get; set; }

        [JsonProperty("activatedBy")]
        public WhoBy ActivatedBy { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("originalEstimate")]
        public int OriginalEstimate { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
