using NUnit.Allure.Core;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.IvrInfoExtractor;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.IvrInfoExtractor
{
    [TestFixture]
    [AllureNUnit]
    public class TranscriptExtractionTests : BaseApiTest
    {
        [TestCase("3fa85f64-5717-4562-b3fc-2c963f66afa6", "IvrInfoExtractor Auto-Message...", "3fa85f64-5717-4562-b3fc-2c963f66afa6", 
            ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_IvrInfoExtractor_TranscriptExtraction_POST_200")]
        public async Task TranscriptExtraction(string participant, string message, string extractFromParticipant, ResponseStatus status, HttpStatusCode code)
        {
            Statement statement = new Statement
            {
                Participant = participant,
                Message = message
            };

            List<Statement> statements = new List<Statement>();
            statements.Add(statement);

            TranscriptExtraction payload = new TranscriptExtraction
            {
                ExtractFromParticipant = extractFromParticipant,
                Statements = statements
            };

            RestRequest request = new RestRequest(IvrInfoExtractorEndpoints.GetTranscriptExtractionEndpoint(), Method.Post)
                .AddJsonBody(payload);

            RestResponse<TranscriptExtraction> response = await extractClient.ExecuteAsync<TranscriptExtraction>(request);

            TranscriptExtraction transcriptExtraction = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }
    }
}
