using Newtonsoft.Json;
using RCM.API.Models.Calls;

namespace RCM.API.Models.Claims
{
    public class CallJobData
    {
        [JsonProperty("oaiClaimId")]
        public string OaiClaimId { get; set; }

        [JsonProperty("jobId")]
        public string JobId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("disposition")]
        public int Disposition { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("jobRequested")]
        public string JobRequested { get; set; }

        [JsonProperty("jobQueued")]
        public string JobQueued { get; set; }

        [JsonProperty("jobStarted")]
        public string JobStarted { get; set; }

        [JsonProperty("jobCompleted")]
        public string JobCompleted { get; set; }

        [JsonProperty("job")]
        public Job Job { get; set; }
    }
}
