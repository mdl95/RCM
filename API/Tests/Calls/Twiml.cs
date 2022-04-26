using NUnit.Framework;
using RCM.API.Endpoints;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class Twiml : BaseApiTest
    {
        string jobId = "";

        [OneTimeSetUp]
        public async Task BeginSettingTestClassJobId()
        {
            jobId = await SetJobIdAsync();
        }


        [Test]
        public async Task API_Calls_Twiml_GET_200()
        {
            RestRequest request = new RestRequest(CallsEndpoints.GetTwimlEndpoint(jobId), Method.Get);

            RestResponse<Twiml> response = await callsClient.ExecuteAsync<Twiml>(request);

            Twiml callStatusCallback = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }

        [Test, Ignore("Implement")]
        public async Task API_Calls_CallStatusCallbacks_ConversationId_POST_200()
        {
        }

        [Test, Ignore("Implement")]
        public async Task API_Calls_CallStatusCallbacks_ParticipantId_POST_200()
        {
        }
    }
}
