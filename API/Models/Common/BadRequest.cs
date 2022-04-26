using Newtonsoft.Json;
using RCM.API.Models.Calls;
using System.Collections.Generic;

namespace RCM.API.Models.Common
{
    public class BadRequest
    {
        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("instance")]
        public string Instance { get; set; }

        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set;}

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        // Template for varying # of additionalProps
        // Be sure to change names of both JsonProperty and property
        [JsonProperty("additionalProp")]
        public string AdditionalProp { get; set; }
    }
}