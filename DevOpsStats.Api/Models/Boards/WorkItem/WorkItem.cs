using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Boards.WorkItem
{
    public class WorkItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rev")]
        public int Rev { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("fields")] 
        public Fields Fields { get; set; }
    }
}
