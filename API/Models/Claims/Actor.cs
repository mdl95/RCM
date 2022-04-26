using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class Actor
    {
        [JsonProperty("actorId")]
        public string ActorId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
