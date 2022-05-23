using FluentValidation.Results;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Common;
using RCM.API.Validators.Common;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.IvrInfoExtractor
{
    public class HealthTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_IvrInfoExtractor_Health_GET_200")]
        public async Task Health(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(CommonEndpoints.GetHealthEndpoint(), Method.Get);

            RestResponse<Health> response = await callsClient.ExecuteAsync<Health>(request);

            Health health = response.Data;

            HealthValidator validator = new HealthValidator();
            ValidationResult results = validator.Validate(health);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(health.Branch, Is.Not.Null);
                Assert.That(health.Commit, Is.Not.Null);

                Assert.That(results.IsValid, Is.True);

                LogResults(response, results);
            });
        }
    }
}
