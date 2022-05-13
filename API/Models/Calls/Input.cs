using Newtonsoft.Json;

namespace Automation.API.Models.Calls
{
    public class Input
    {
        [JsonProperty("auth_date")]
        public string AuthDate { get; set; }

        [JsonProperty("auth_id")]
        public string AuthId { get; set; }

        [JsonProperty("biller_name")]
        public string BillerName { get; set; }

        [JsonProperty("biller_npi")]
        public string BillerNpi { get; set; }

        [JsonProperty("callInformation_taxId")]
        public string CallInformationTaxId { get; set; }

        [JsonProperty("claim_billed_amount")]
        public string ClaimBilledAmount { get; set; }

        [JsonProperty("claim_claimDateOfService")]
        public string Claim_ClaimDateOfService { get; set; }

        [JsonProperty("claim_submission_date")]
        public string ClaimSubmissionDate { get; set; }

        [JsonProperty("date_of_provision_or_admission")]
        public string DateOfProvisionOrAdmission { get; set; }

        [JsonProperty("discharge_date")]
        public string DischargeDate { get; set; }
        
        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("insurer_claim_id")]
        public string InsurerClaimId { get; set; }

        [JsonProperty("insurer_id")]
        public string InsurerId { get; set; }

        [JsonProperty("insurer_name")]
        public string InsurerName { get; set; }

        [JsonProperty("insurer_phone_number")]
        public string InsurerPhoneNumber { get; set; }

        [JsonProperty("insurer_plan_name")]
        public string InsurerPlanName { get; set; }

        [JsonProperty("oai_worked")]
        public string OaiWorked { get; set; }

        [JsonProperty("outstanding_balance")]
        public string OutstandingBalance { get; set; }

        [JsonProperty("patient_city")]
        public string PatientCity { get; set; }

        [JsonProperty("patient_dateOfBirth")]
        public string PatientDateOfBirth { get; set; }

        [JsonProperty("patient_dob")]
        public string PatientDob { get; set; }

        [JsonProperty("patient_first_name")]
        public string PatientFirstName { get; set; }

        [JsonProperty("patient_id")]
        public string PatientId { get; set; }

        [JsonProperty("patient_last_name")]
        public string PatientLastName { get; set; }

        [JsonProperty("patient_memberId")]
        public string PatientMemberId { get; set; }

        [JsonProperty("patient_sex")]
        public string PatientSex { get; set; }

        [JsonProperty("patient_state")]
        public string PatientState { get; set; }

        [JsonProperty("patient_street1")]
        public string PatientStreet1 { get; set; }

        [JsonProperty("patient_street2")]
        public string PatientStreet2 { get; set; }

        [JsonProperty("patient_zip")]
        public string PatientZip { get; set; }

        [JsonProperty("plan_paid_amount")]
        public string PlanPaidAmount { get; set; }

        [JsonProperty("subscriber_dob")]
        public string SubscriberDob { get; set; }

        [JsonProperty("subscriber_id")]
        public string SubscriberId { get; set; }

        [JsonProperty("subscriber_first_name")]
        public string SubscriberFirstName { get; set; }

        [JsonProperty("subscriber_last_name")]
        public string SubscriberLastName { get; set; }

        [JsonProperty("subscriber_relationship")]
        public string SubscriberRelationship { get; set; }

        [JsonProperty("subscriber_sex")]
        public string SubscriberSex { get; set; }

        [JsonProperty("visit_id")]
        public string VisitId { get; set; }
    }
}