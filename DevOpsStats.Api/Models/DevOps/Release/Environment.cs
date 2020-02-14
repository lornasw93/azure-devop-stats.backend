using System.Collections.Generic; 
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Release
{
    public class Environment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("releaseId")]
        public int ReleaseId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("variables")]
        public object Variables { get; set; }

        [JsonProperty("releaseDefinition")]
        public Definition Definition { get; set; }

        [JsonProperty("deploySteps")]
        public List<DeployStep> DeploySteps { get; set; }
    }
}
