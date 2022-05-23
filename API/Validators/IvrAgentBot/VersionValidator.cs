using FluentValidation;
using RCM.API.Models.IvrAgentBot;
using RCM.API.Support;

namespace RCM.API.Validators.IvrAgentBot
{
    public class VersionValidator : AbstractValidator<VersionModel>
    {
        public VersionValidator()
        {
            RuleFor(version => version.Version).IsString();
        }
    }
}
