using Newtonsoft.Json;
using System;

namespace RCM.API.Models.Calls
{
    public class TranscriptsData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("participantId")]
        public string ParticipantId { get; set; }

        [JsonProperty("participantType")]
        public string ParticipantType { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("startTime")]
        public double StartTime { get; set; }

        [JsonProperty("endTime")]
        public double EndTime { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
