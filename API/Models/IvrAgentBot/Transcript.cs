using Automation.API.Models.Calls;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.IvrAgentBot
{
    public class Transcript
    {
        [JsonProperty("conversationID")]
        public string ConversationID { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("metadata")]
        public Input Metadata { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("entities")]
        public List<Entities> Entities { get; set; }

        [JsonProperty("partsOfSpeech")]
        public List<PartsOfSpeech> PartsOfSpeech { get; set; }
    }
}