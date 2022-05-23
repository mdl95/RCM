using FluentValidation;
using RCM.API.Models.IvrInfoExtractor;
using RCM.API.Support;

namespace RCM.API.Validators.IvrInfoExtractor
{
    public class TranscriptExtractionValidator : AbstractValidator<TranscriptExtraction>
    {
        public TranscriptExtractionValidator()
        {
            RuleFor(extract => extract.EntityExtractions[0].EntityId).IsString();
            RuleFor(extract => extract.EntityExtractions[0].EntityValue).IsString();
            RuleFor(extract => extract.EntityExtractions[0].Confidence).IsDouble();
        }     
    }
}
