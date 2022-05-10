using FluentValidation;
using RCM.API.Models.Claims;

namespace RCM.API.Validators.Claims
{
    public class CsvClaimValidator :AbstractValidator<CsvClaim>
    {
        public CsvClaimValidator()
        {

        }
    }
}
