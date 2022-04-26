using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class Established
    {
        [JsonProperty("entityBagId")]
        public string EntityBagId { get; set; }

        [JsonProperty("predecessorId")]
        public string PredecessorId { get; set; }

        [JsonProperty("actorId")]
        public string ActorId { get; set; }

        [JsonProperty("actorName")]
        public string ActorName { get; set; }

        [JsonProperty("activityId")]
        public string ActivityId { get; set; }

        [JsonProperty("callJobId")]
        public string CallJobId { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("activity")]
        public Activity Activity { get; set; }

        [JsonProperty("actor")]
        public Actor Actor { get; set; }

        [JsonProperty("callJob")]
        public CallJobData CallJob { get; set; }
    }
}
