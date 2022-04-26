using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class EntityVersion
    {
        [JsonProperty("entityVersionId")]
        public string EntityVersionId { get; set; }

        [JsonProperty("entity")]
        public Entity Entity { get; set; }

        [JsonProperty("entityValue")]
        public string EntityValue { get; set; }

        [JsonProperty("establishedId")]
        public string EstablishedId { get; set; }

        [JsonProperty("established")]
        public Established Established { get; set; }

        [JsonProperty("evIdPrevious")]
        public string EvIdPrevious { get; set; }
    }
}
