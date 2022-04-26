using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class Activity
    {
        [JsonProperty("activityId")]
        public string ActivityId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
