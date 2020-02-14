using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.TestPlan
{
    public class TestPlan
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("isAutomated")]
        public bool IsAutomated { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("totalTests")]
        public int TotalTests { get; set; }

        [JsonProperty("incompleteTests")]
        public int IncompleteTests { get; set; }

        [JsonProperty("notApplicableTests")]
        public int NotApplicableTests { get; set; }

        [JsonProperty("passedTests")]
        public int PassedTests { get; set; }

        [JsonProperty("unanalyzedTests")]
        public int UnanalysedTests { get; set; }

        [JsonProperty("revision")]
        public int Revision { get; set; }

        [JsonProperty("webAccessUrl")]
        public string WebAccessUrl { get; set; }
    }
}
