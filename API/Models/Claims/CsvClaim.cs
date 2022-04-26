using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RCM.API.Models.Claims
{
    public class CsvClaim
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("data")]
        public List<CsvClaimData> Data { get; set; }
    }
}