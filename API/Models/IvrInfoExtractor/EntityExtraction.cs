using Newtonsoft.Json;

namespace RCM.API.Models.IvrInfoExtractor
{
    public class EntityExtraction
    {
        [JsonProperty("entityId")]
        public string EntityId { get; set; }

        [JsonProperty("entityValue")]
        public string EntityValue { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
}