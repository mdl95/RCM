using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.Claims
{
    public class EntityBag
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("data")]
        public List<EntityBagData> Data { get; set; }

        [JsonProperty("entityVersions")]
        public List<EntityVersion> EntityVersions { get; set; }
    }
}