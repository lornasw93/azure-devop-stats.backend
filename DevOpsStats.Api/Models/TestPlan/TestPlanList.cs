using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models.TestPlan
{
    public class TestPlanList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<TestPlan> Value { get; set; }
    }
}
