using Newtonsoft.Json;

namespace RCM.API.Models.Common
{
    public class Error
    {
        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("transient")]
        public bool Transient { get; set; }
    }
}