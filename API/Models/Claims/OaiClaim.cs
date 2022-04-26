using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.Claims
{
    public class OaiClaim
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("data")]
        public List<OaiClaimData> Data { get; set; }

        [JsonProperty("occurrences")]
        public List<Occurrence> Occurrences { get; set; }

        [JsonProperty("entityBagId")]
        public string EntityBagId { get; set; }

        [JsonProperty("predecessorId")]
        public string PredecessorId { get; set; }

        [JsonProperty("actorPool")]
        public string ActorPool { get; set; }

        [JsonProperty("actorUser")]
        public string ActorUser { get; set; }

        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("entityVersions")]
        public List<EntityVersion> EntityVersions { get; set; }

        [JsonProperty("actorId")]
        public string ActorId { get; set; }

        [JsonProperty("actorName")]
        public string ActorName { get; set; }

        [JsonProperty("activityId")]
        public string ActivityId { get; set; }
    }
}