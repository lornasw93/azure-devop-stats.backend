using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Release
{
    public class DeployStep
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("deploymentId")]
        public int DeploymentId { get; set; }

        [JsonProperty("attempt")]
        public int Attempt { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("operationStatus")]
        public string OperationStatus { get; set; }

        [JsonProperty("requestedBy")]
        public User RequestedBy { get; set; }
    }
}
