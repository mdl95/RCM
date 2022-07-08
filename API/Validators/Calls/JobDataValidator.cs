using FluentValidation;
using RCM.API.Models.Calls;
using RCM.API.Support;

namespace RCM.API.Validators.Calls
{
    public class JobDataValidator : AbstractValidator<JobData>
    {
        public JobDataValidator()
        {
            RuleFor(job => job.Id).IsString();
            RuleFor(job => job.Type).IsString();
            RuleFor(job => job.Status).IsString();
            RuleFor(job => job.PhoneNumber).IsString();
            RuleFor(job => job.CallbackUri).IsString();
            RuleFor(job => job.Created).IsDateTime();
            RuleFor(job => job.Updated).IsDateTime();
            RuleFor(job => job.Version).IsInteger();
        }
    }
}
