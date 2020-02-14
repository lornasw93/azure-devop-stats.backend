using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps.Iteration
{
    public class Attribute
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("finishDate")]
        public string FinishDate { get; set; }

        [JsonProperty("timeFrame")]
        public string TimeFrame { get; set; }
    }
}
