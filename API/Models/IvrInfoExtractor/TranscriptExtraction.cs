using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.IvrInfoExtractor
{
    public class TranscriptExtraction
    {
        [JsonProperty("extractFromParticipant")]
        public string ExtractFromParticipant { get; set; }

        [JsonProperty("statements")]
        public List<Statement> Statements { get; set; }
    }
}
