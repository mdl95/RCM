using Automation.API.Models.Calls;
using Newtonsoft.Json;
using RCM.API.Models.Common;
using System;
using System.Collections.Generic;

namespace RCM.API.Models.Calls
{
    public class JobData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("callbackUri")]
        public string CallbackUri { get; set; }

        [JsonProperty("inputs")]
        public Input Inputs { get; set; }

        [JsonProperty("outputs")]
        public Output Outputs { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
