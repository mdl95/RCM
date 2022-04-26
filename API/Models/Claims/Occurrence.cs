using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class Occurrence
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
