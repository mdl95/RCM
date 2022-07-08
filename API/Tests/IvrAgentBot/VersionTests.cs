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
    public class VersionTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_IvrAgentBot_Version_GET_200")]
        public async Task Version(ResponseStatus responseStatus, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(IvrAgentBotEndpoints.GetVersionEndpoint(), Method.Get);

            RestResponse<VersionModel> response = await agentClient.ExecuteAsync<VersionModel>(request);

            VersionModel version = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(responseStatus));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }
    }
}
