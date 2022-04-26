using Newtonsoft.Json;

namespace RCM.API.Models.Common
{
    public class Health
    {
        // Health GET Response

        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("commit")]
        public string Commit { get; set; }
    }
}
