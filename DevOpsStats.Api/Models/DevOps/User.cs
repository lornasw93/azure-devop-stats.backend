﻿using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.DevOps
{
    public class User
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
         
        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }
    }
}
