using FluentValidation;
using RCM.API.Models.Claims;
using RCM.API.Support;

namespace RCM.API.Validators.Claims
{
    public class CallJobDataValidator : AbstractValidator<CallJobData>
    {
        public CallJobDataValidator()
        {
            RuleFor(callJob => callJob.OaiClaimId).IsString();
            RuleFor(callJob => callJob.JobId).IsString();
            RuleFor(callJob => callJob.Status).InclusiveBetween(0, 3);
            RuleFor(callJob => callJob.PhoneNumber).IsString();
            RuleFor(callJob => callJob.Disposition).InclusiveBetween(1, 6);
            RuleFor(callJob => callJob.Notes).IsString();
            RuleFor(callJob => callJob.JobRequested).IsDateTime();
            RuleFor(callJob => callJob.JobQueued).IsDateTime();
            RuleFor(callJob => callJob.JobStarted).IsDateTime();
            RuleFor(callJob => callJob.JobCompleted).IsDateTime();
            RuleFor(callJob => callJob.Job).IsJob();
        }
    }
}
