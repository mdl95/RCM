using NUnit.Allure.Core;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.IvrAgentBot;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.IvrAgentBot
{
    [TestFixture]
    [AllureNUnit]
    public class StatusTests : BaseApiTest
    {
        [TestCase("OK", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_IvrAgentBot_Status_GET_200")]
        public async Task Status(string expectedStatus, ResponseStatus responseStatus, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(IvrAgentBotEndpoints.GetStatusEndpoint(), Method.Get);

            RestResponse<StatusModel> response = await agentClient.ExecuteAsync<StatusModel>(request);

            StatusModel status = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(responseStatus));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(status.Status, Is.EqualTo(expectedStatus));

                LogResults(response);
            });
        }
    }
}
