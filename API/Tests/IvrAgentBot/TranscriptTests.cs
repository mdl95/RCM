using Automation.API.Models.Calls;
using FluentValidation.Results;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.IvrAgentBot;
using RCM.API.Validators.IvrAgentBot;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.IvrAgentBot
{
    public class TranscriptTests : BaseApiTest
    {
        [TestCase("", "Transcript auto-message...", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_IvrAgentBot_Transcript_POST_200"), Ignore("Need ConversationId")]
        public async Task Transcript(string conversationId, string message, ResponseStatus status, HttpStatusCode code)
        {
            Input metadata = new Input
            {
                PatientFirstName = "AutoFirstName",
                PatientLastName = "AutoLastName"
            };

            Transcript payload = new Transcript
            {
                ConversationID = conversationId,
                Message = message,
                Metadata = metadata
            };

            RestRequest request = new RestRequest(IvrAgentBotEndpoints.GetTranscriptEndpoint(), Method.Post)
                .AddJsonBody(payload);

            RestResponse<Transcript> response = await agentClient.ExecuteAsync<Transcript>(request);

            Transcript transcript = response.Data;

            TranscriptValidator validator = new TranscriptValidator();
            ValidationResult results = validator.Validate(transcript);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                Assert.That(results.IsValid, Is.True);

                LogResults(response, results);
            });
        }
    }
}
