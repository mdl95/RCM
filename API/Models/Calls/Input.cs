using Newtonsoft.Json;

namespace Automation.API.Models.Calls
{
    public class Input
    {
        [JsonProperty("claim_claimDateOfService")]
        public string Claim_ClaimDateOfService { get; set; }

        [JsonProperty("patient_dateOfBirth")]
        public string Patient_DateOfBirth { get; set; }

        [JsonProperty("patient_memberId")]
        public string Patient_MemberId { get; set; }

        [JsonProperty("callInformation_taxId")]
        public string CallInformation_TaxId { get; set; }
    }
}