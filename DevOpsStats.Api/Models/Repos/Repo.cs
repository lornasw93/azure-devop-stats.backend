using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Repos
{
    public class Repo
    {
        [JsonRequired, JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("project")]
        public Project.Project Project { get; set; }
        
        public int PushCount { get; set; }
    }
}
