using Newtonsoft.Json;

namespace RCM.API.Models.IvrInfoExtractor
{
    public class Statement
    {
        [JsonProperty("participant")]
        public string Participant { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
