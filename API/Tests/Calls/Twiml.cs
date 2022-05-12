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


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Twiml_GET_200")]
        public async Task Calls_Twiml(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(CallsEndpoints.GetTwimlEndpoint(jobId), Method.Get);

            RestResponse<Twiml> response = await callsClient.ExecuteAsync<Twiml>(request);

            Twiml callStatusCallback = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }

        [TestCase(TestName = "API_Calls_Twiml_ConversationId_POST_200"), Ignore("Implement")]
        public async Task Twiml_ConversationId()
        {
        }

        [TestCase(TestName = "API_Calls_Twiml_ParticipantId_POST_200"), Ignore("Implement")]
        public async Task Twiml_ParticipantId()
        {
        }
    }
}
