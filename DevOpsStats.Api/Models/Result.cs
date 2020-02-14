using System.ComponentModel;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Models
{
    public class Result
    {
        [Description("Count")]
        public int Count { get; set; }

        [Description("Description")]
        public string Description { get; set; }
    }
}
