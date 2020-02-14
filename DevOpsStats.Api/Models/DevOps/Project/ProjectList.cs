using System.Collections.Generic; 
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Project
{
    public class ProjectList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<Project> Value { get; set; }
    }
}
