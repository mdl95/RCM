using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class EntityData
    {
        [JsonProperty("entityId")]
        public string EntityId { get; set; }

        [JsonProperty("slot")]
        public string Slot { get; set; }

        [JsonProperty("typeId")]
        public string TypeId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}