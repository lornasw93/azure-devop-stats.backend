using System; 
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Commit
{
    public class ChangeCounts
    {
        [JsonProperty("Add")]
        public int Add { get; set; }

        [JsonProperty("Edit")]
        public int Edit { get; set; }

        [JsonProperty("Delete")]
        public int Delete { get; set; }
    }
}
