using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class CsvClaimData
    {
        [JsonProperty("csvClaimId")]
        public string CsvClaimId { get; set; }

        [JsonProperty("oaiClaimId")]
        public string OaiClaimId { get; set; }

        [JsonProperty("csvImportId")]
        public string CsvImportId { get; set; }

        [JsonProperty("csvLineNumber")]
        public int CsvLineNumber { get; set; }

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

        [JsonProperty("patientSex")]
        public string PatientSex { get; set; }

        [JsonProperty("patientDob")]
        public string PatientDob { get; set; }

        [JsonProperty("admitDate")]
        public string AdmitDate { get; set; }

        [JsonProperty("dischargeDate")]
        public string DischargeDate { get; set; }

        [JsonProperty("patientStreet1")]
        public string PatientStreet1 { get; set; }

        [JsonProperty("patientStreet2")]
        public string PatientStreet2 { get; set; }

        [JsonProperty("patientCity")]
        public string PatientCity { get; set; }

        [JsonProperty("patientState")]
        public string PatientState { get; set; }

        [JsonProperty("patientZip")]
        public string PatientZip { get; set; }

        [JsonProperty("insurerId")]
        public string InsurerId { get; set; }

        [JsonProperty("insurerName")]
        public string InsurerName { get; set; }

        [JsonProperty("insurerPhoneNumber")]
        public string InsurerPhoneNumber { get; set; }

        [JsonProperty("insurerPlanName")]
        public string InsurerPlanName { get; set; }

        [JsonProperty("subscriberFirstName")]
        public string SubscriberFirstName { get; set; }

        [JsonProperty("subscriberLastName")]
        public string SubscriberLastName { get; set; }

        [JsonProperty("subscriberSex")]
        public string SubscriberSex { get; set; }

        [JsonProperty("subscriberDob")]
        public string SubscriberDob { get; set; }

        [JsonProperty("subscriberId")]
        public string SubscriberId { get; set; }

        [JsonProperty("subscriberRelationship")]
        public string SubscriberRelationship { get; set; }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("claimId")]
        public string ClaimId { get; set; }

        [JsonProperty("claimSubmissionDate")]
        public string ClaimSubmissionDate { get; set; }

        [JsonProperty("claimAmount")]
        public double ClaimAmount { get; set; }

        [JsonProperty("outstandingBalance")]
        public double OutstandingBalance { get; set; }

        [JsonProperty("authId")]
        public string AuthId { get; set; }

        [JsonProperty("authDate")]
        public string AuthDate { get; set; }
    }
}