using Newtonsoft.Json;

namespace RCM.API.Models.Calls
{
    public class RecordingStatusCallback
    {
        [JsonProperty("accountSid")]
        public string AccountSid { get; set; }

        [JsonProperty("callSid")]
        public string CallSid { get; set; }

        [JsonProperty("recordingSid")]
        public string RecordingSid { get; set; }

        [JsonProperty("recordingUrl")]
        public string RecordingUrl { get; set; }

        [JsonProperty("recordingStatus")]
        public string RecordingStatus { get; set; }

        [JsonProperty("recordingDuration")]
        public string RecordingDuration { get; set; }

        [JsonProperty("recordingChannels")]
        public string RecordingChannels { get; set; }

        [JsonProperty("recordingStartTime")]
        public string RecordingStartTime { get; set; }

        [JsonProperty("recordingSource")]
        public string RecordingSource { get; set; }

        [JsonProperty("recordingTrack")]
        public string RecordingTrack { get; set; }
    }
}