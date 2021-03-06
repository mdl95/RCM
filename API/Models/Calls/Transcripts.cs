using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.Calls
{
    public class Transcripts
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
        
        [JsonProperty("data")]
        public List<TranscriptsData> Data { get; set; }
    }
}
