using FluentValidation;
using RCM.API.Models.IvrAgentBot;
using RCM.API.Support;

namespace RCM.API.Validators.IvrAgentBot
{
    public class TranscriptValidator : AbstractValidator<Transcript>
    {
        public TranscriptValidator()
        {
            RuleFor(transcript => transcript.ConversationID).IsString();
            RuleFor(transcript => transcript.Request).IsString();
            RuleFor(transcript => transcript.Action).IsString();
            RuleFor(transcript => transcript.Response).IsString();
            RuleFor(transcript => transcript.Entities[0].BeginOffset).IsInteger();
            RuleFor(transcript => transcript.Entities[0].EndOffset).IsInteger();
            RuleFor(transcript => transcript.Entities[0].Score).IsFloat();
            RuleFor(transcript => transcript.Entities[0].Text).IsString();
            RuleFor(transcript => transcript.Entities[0].Type).IsString();
            RuleFor(transcript => transcript.Entities[0].MillisecondsToFetch).IsDouble();
            RuleFor(transcript => transcript.PartsOfSpeech[0].TokenID).IsInteger();
            RuleFor(transcript => transcript.PartsOfSpeech[0].BeginOffset).IsInteger();
            RuleFor(transcript => transcript.PartsOfSpeech[0].EndOffset).IsInteger();
            RuleFor(transcript => transcript.PartsOfSpeech[0].Text).IsString();
            RuleFor(transcript => transcript.PartsOfSpeech[0].MillisecondsToFetch).IsDouble();
            RuleFor(transcript => transcript.PartsOfSpeech[0].PrimaryScore).IsFloat();
            RuleFor(transcript => transcript.PartsOfSpeech[0].PrimaryTag).IsString();
        }
    }
}
