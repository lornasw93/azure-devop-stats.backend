using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Boards.WorkItem
{
    public class Links
    {
        [JsonProperty("avatar")]
        public Badge Avatar { get; set; }
    }
}
