using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Boards.Sprint
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
