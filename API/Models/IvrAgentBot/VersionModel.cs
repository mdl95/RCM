using Newtonsoft.Json;

namespace RCM.API.Models.IvrAgentBot
{
    public class VersionModel
    {
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
