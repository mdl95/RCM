using FluentValidation;
using RCM.API.Models.Claims;
using RCM.API.Support;

namespace RCM.API.Validators.Claims
{
    public class CsvClaimDataValidator : AbstractValidator<CsvClaimData>
    {
        public CsvClaimDataValidator()
        {
            RuleFor(claim => claim.CsvClaimId).IsString();
            RuleFor(claim => claim.OaiClaimId).IsString();
            RuleFor(claim => claim.CsvImportId).IsString();
            RuleFor(claim => claim.CsvLineNumber).IsInteger();
            RuleFor(claim => claim.PatientId).IsString();
            RuleFor(claim => claim.VisitId).IsString();
            RuleFor(claim => claim.BillerNpi).IsString();
            RuleFor(claim => claim.BillerTaxId).IsString();
            RuleFor(claim => claim.BillerName).IsString();
            RuleFor(claim => claim.PatientFirstName).IsString();
            RuleFor(claim => claim.PatientLastName).IsString();
            RuleFor(claim => claim.PatientSex).IsString();
            RuleFor(claim => claim.PatientDob).IsDateTime();
            RuleFor(claim => claim.AdmitDate).IsDateTime();
            RuleFor(claim => claim.DischargeDate).IsDateTime();
            RuleFor(claim => claim.PatientStreet1).IsString();
            RuleFor(claim => claim.PatientStreet2).IsString();
            RuleFor(claim => claim.PatientCity).IsString();
            RuleFor(claim => claim.PatientState).IsString();
            RuleFor(claim => claim.PatientZip).IsString();
            RuleFor(claim => claim.InsurerId).IsString();
            RuleFor(claim => claim.InsurerName).IsString();
            RuleFor(claim => claim.InsurerPhoneNumber).IsString();
            RuleFor(claim => claim.InsurerPlanName).IsString();
            RuleFor(claim => claim.SubscriberFirstName).IsString();
            RuleFor(claim => claim.SubscriberLastName).IsString();
            RuleFor(claim => claim.SubscriberSex).IsString();
            RuleFor(claim => claim.SubscriberDob).IsDateTime();
            RuleFor(claim => claim.SubscriberId).IsString();
            RuleFor(claim => claim.SubscriberRelationship).IsString();
            RuleFor(claim => claim.GroupId).IsString();
            RuleFor(claim => claim.ClaimId).IsString();
            RuleFor(claim => claim.ClaimSubmissionDate).IsDateTime();
            RuleFor(claim => claim.ClaimAmount).IsDouble();
            RuleFor(claim => claim.OutstandingBalance).IsDouble();
            RuleFor(claim => claim.AuthId).IsString();
            RuleFor(claim => claim.AuthDate).IsDateTime();
        }
    }
}
