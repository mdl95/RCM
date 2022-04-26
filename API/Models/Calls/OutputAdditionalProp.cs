using Newtonsoft.Json;

namespace RCM.API.Models.Calls
{
    public class OutputAdditionalProp
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
}