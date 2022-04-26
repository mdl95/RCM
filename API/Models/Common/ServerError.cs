using Newtonsoft.Json;
using RCM.API.Models.Calls;
using System.Collections.Generic;

namespace RCM.API.Models.Common
{
    public class ServerError
    {
        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
