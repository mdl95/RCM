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
        }
    }
}
