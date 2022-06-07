using FluentValidation;
using RCM.API.Models.Claims;
using RCM.API.Support;

namespace RCM.API.Validators.Claims
{
    public class CallJobValidator : AbstractValidator<CallJob>
    {
        public CallJobValidator()
        {
            RuleFor(callJob => callJob.Count).IsInteger();
            RuleFor(callJob => callJob.Limit).IsInteger();
            RuleFor(callJob => callJob.Offset).IsLong();
        }
    }
}
