using Newtonsoft.Json;

namespace RCM.API.Models.IvrAgentBot
{
    public class StatusModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
