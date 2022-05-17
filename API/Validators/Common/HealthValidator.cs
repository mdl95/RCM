using FluentValidation;
using RCM.API.Models.Common;
using RCM.API.Support;

namespace RCM.API.Validators.Common
{
    public class HealthValidator : AbstractValidator<Health>
    {
        public HealthValidator()
        {
            RuleFor(health => health.Branch).IsString();
            RuleFor(health => health.Commit).IsString();
        }
    }
}
