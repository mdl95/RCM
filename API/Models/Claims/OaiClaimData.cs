using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.Claims
{
    public class OaiClaimData
    {
        [JsonProperty("oaiClaimId")]
        public string OaiClaimId { get; set; }

        [JsonProperty("oaiStatus")]
        public string OaiStatus { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("insurerName")]
        public string InsurerName { get; set; }

        [JsonProperty("insurerPlanName")]
        public string InsurerPlanName { get; set; }

        [JsonProperty("insurerClaimId")]
        public string InsurerClaimId { get; set; }

        [JsonProperty("patientId")]
        public string PatientId { get; set; }

        [JsonProperty("visitId")]
        public string VisitId { get; set; }

        [JsonProperty("billerNpi")]
        public string BillerNpi { get; set; }

        [JsonProperty("billerTaxId")]
        public string BillerTaxId { get; set; }

        [JsonProperty("billerName")]
        public string BillerName { get; set; }

        [JsonProperty("patientFirstName")]
        public string PatientFirstName { get; set; }

        [JsonProperty("patientLastName")]
        public string PatientLastName { get; set; }

        [JsonProperty("patientDob")]
        public string PatientDob { get; set; }

        [JsonProperty("admitDate")]
        public string AdmitDate { get; set; }

        [JsonProperty("patientState")]
        public string PatientState { get; set; }

        [JsonProperty("insurerId")]
        public string InsurerId { get; set; }

        [JsonProperty("subscriberFirstName")]
        public string SubscriberFirstName { get; set; }

        [JsonProperty("subscriberLastName")]
        public string SubscriberLastName { get; set; }

        [JsonProperty("subscriberId")]
        public string SubscriberId { get; set; }

        [JsonProperty("claimSubmissionDate")]
        public string ClaimSubmissionDate { get; set; }

        [JsonProperty("claimAmount")]
        public double ClaimAmount { get; set; }

        [JsonProperty("outstandingBalance")]
        public double OutstandingBalance { get; set; }

        [JsonProperty("claimDisposition")]
        public string ClaimDisposition { get; set; }

        [JsonProperty("oaiWorked")]
        public string OaiWorked { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("entityBag")]
        public EntityBag EntityBag { get; set; }

        [JsonProperty("callJobs")]
        public List<CallJob> CallJob { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
