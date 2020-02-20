using System;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Commit
{
    public class Who
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

}
