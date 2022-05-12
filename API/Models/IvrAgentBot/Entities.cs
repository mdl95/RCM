using Newtonsoft.Json;

namespace RCM.API.Models.IvrAgentBot
{
    public class Entities
    {
        [JsonProperty("beginOffset")]
        public int BeginOffset { get; set; }

        [JsonProperty("endOffset")]
        public int EndOffset { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("millisecondsToFetch")]
        public double MillisecondsToFetch { get; set; }

    }
}
