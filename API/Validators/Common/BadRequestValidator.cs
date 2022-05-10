using FluentValidation;
using RCM.API.Models.Common;

namespace RCM.API.Validators.Common
{
    public class BadRequestValidator : AbstractValidator<BadRequest>
    {
        public BadRequestValidator()
        {

        }
    }
}
