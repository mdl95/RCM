using FluentValidation;
using RCM.API.Models.Common;
using RCM.API.Support;

namespace RCM.API.Validators.Common
{
    public class BadRequestValidator : AbstractValidator<BadRequest>
    {
        public BadRequestValidator()
        {
            RuleFor(request => request.Type).IsString();
            RuleFor(request => request.Title).IsString();
            RuleFor(request => request.Status).IsInteger();
            RuleFor(request => request.Detail).IsString();
            RuleFor(request => request.Instance).IsString();

            // TODO: AdditionalProps
        }
    }
}
