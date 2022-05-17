using FluentValidation;
using RCM.API.Models.Calls;
using RCM.API.Support;

namespace RCM.API.Validators.Calls
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(job => job.Count).IsInteger();
            RuleFor(job => job.Limit).IsInteger();
            RuleFor(job => job.Offset).IsLong();
            RuleFor(job => job.Data[0].Id).IsString();
            RuleFor(job => job.Data[0].Type).IsString();
            RuleFor(job => job.Data[0].Status).IsString();
            RuleFor(job => job.Data[0].PhoneNumber).IsString();
            RuleFor(job => job.Data[0].CallbackUri).IsString();
            RuleFor(job => job.Data[0].Created).IsDateTime();
            RuleFor(job => job.Data[0].Updated).IsDateTime();
            RuleFor(job => job.Data[0].Version).IsInteger();
        }
    }
}
