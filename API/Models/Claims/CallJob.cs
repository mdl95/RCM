using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.Claims
{
    public class CallJob
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("data")]
        public List<CallJobData> Data { get; set; }


        [JsonProperty("jobId")]
        public string JobId { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
