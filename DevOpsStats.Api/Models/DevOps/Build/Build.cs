using System;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Build
{
    public class Build
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("buildNumber")]
        public string BuildNumber { get; set; }
         
        [JsonProperty("requestedFor")]
        public User RequestedFor { get; set; }

        [JsonProperty("queueTime")]
        public DateTime QueueTime { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("_links")]
        public Link Links { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("finishTime")]
        public DateTime FinishTime { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("definition")]
        public Definition Definition { get; set; }

        [JsonProperty("logs")]
        public Log Log { get; set; }
    }
}
