using Newtonsoft.Json;

namespace RCM.API.Models.IvrAgentBot
{
    public class PartsOfSpeech
    {
        [JsonProperty("tokenID")]
        public int TokenID { get; set; }

        [JsonProperty("beginOffset")]
        public int BeginOffset { get; set; }

        [JsonProperty("endOffset")]
        public int EndOffset { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("millisecondsToFetch")]
        public double MillisecondsToFetch { get; set; }

        [JsonProperty("primaryScore")]
        public float PrimaryScore { get; set; }

        [JsonProperty("primaryTag")]
        public string PrimaryTag { get; set; }
    }
}
