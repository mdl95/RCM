using Newtonsoft.Json;

namespace RCM.API.Models.Calls
{
    public class CallStatusCallback
    {
        [JsonProperty("accountSid")]
        public string AccountSid { get; set; }

        [JsonProperty("callSid")]
        public string CallSid { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("callStatus")]
        public string CallStatus { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("forwardedFrom")]
        public string ForwardedFrom { get; set; }

        [JsonProperty("callerName")]
        public string CallerName { get; set; }

        [JsonProperty("parentCallSid")]
        public string ParentCallSid { get; set; }

        [JsonProperty("callDuration")]
        public string CallDuration { get; set; }

        [JsonProperty("sipResponseCode")]
        public string SipResponseCode { get; set; }

        [JsonProperty("recordingUrl")]
        public string RecordingUrl { get; set; }

        [JsonProperty("recordingSid")]
        public string RecordingSid { get; set; }

        [JsonProperty("recordingDuration")]
        public string RecordingDuration { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("callbackSource")]
        public string CallbackSource { get; set; }

        [JsonProperty("sequenceNumber")]
        public string SequenceNumber { get; set; }
    }
}
