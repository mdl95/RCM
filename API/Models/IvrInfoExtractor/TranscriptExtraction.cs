using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.IvrInfoExtractor
{
    public class TranscriptExtraction
    {
        // REQUEST

        [JsonProperty("extractFromParticipant")]
        public string ExtractFromParticipant { get; set; }

        [JsonProperty("statements")]
        public List<Statement> Statements { get; set; }


        // RESPONSE

        [JsonProperty("entityExtractions")]
        public List<EntityExtraction> EntityExtractions { get; set; }
    }
}
