using FluentValidation;
using RCM.API.Models.IvrAgentBot;
using RCM.API.Support;

namespace RCM.API.Validators.IvrAgentBot
{
    public class StatusValidator : AbstractValidator<StatusModel>
    {
        public StatusValidator()
        {
            RuleFor(status => status.Status).IsString();
        }
    }
}
