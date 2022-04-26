using Newtonsoft.Json;

namespace RCM.API.Models.Calls
{
    public class StreamStatusCallback
    {
        [JsonProperty("accountSid")]
        public string AccountSid { get; set; }

        [JsonProperty("callSid")]
        public string CallSid { get; set; }

        [JsonProperty("streamSid")]
        public string StreamSid { get; set; }

        [JsonProperty("streamName")]
        public string StreamName { get; set; }

        [JsonProperty("streamEvent")]
        public string StreamEvent { get; set; }

        [JsonProperty("streamError")]
        public string StreamError { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
