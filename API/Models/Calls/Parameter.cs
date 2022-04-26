using Newtonsoft.Json;

namespace RCM.API.Models.Calls
{
    public class Parameter
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
