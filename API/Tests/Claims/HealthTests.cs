using NUnit.Allure.Core;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Common;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Claims
{
    [TestFixture]
    [AllureNUnit]
    public class HealthTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_Health_GET_200")]
        public async Task Health(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(CommonEndpoints.GetHealthEndpoint(), Method.Get);

            RestResponse<Health> response = await claimsClient.ExecuteAsync<Health>(request);

            Health health = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }
    }
}
