using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.Pipelines.Release
{
    public class Release
    {
        [JsonRequired, JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
         
        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [JsonProperty("modifiedBy")]
        public object ModifiedBy { get; set; }
        
        [JsonProperty("createdBy")]
        public User CreatedBy { get; set; }
         
        [JsonProperty("releaseDefinition")]
        public object ReleaseDefinition { get; set; }
         
        [JsonProperty("url")]
        public string Url { get; set; } 
    }
}
