using FluentValidation.Results;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Common;
using RCM.API.Validators.Common;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class HealthTests : BaseApiTest
    {
        [Test]
        public async Task API_Calls_Health_GET_200()
        {
            RestRequest request = new RestRequest(CommonEndpoints.GetHealthEndpoint(), Method.Get);

            RestResponse<Health> response = await callsClient.ExecuteAsync<Health>(request);

            Health health = response.Data;

            HealthValidator validator = new HealthValidator();
            ValidationResult results = validator.Validate(health);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(health.Branch, Is.Not.Null);
                Assert.That(health.Commit, Is.Not.Null);

                Assert.That(results.IsValid, Is.True);

                LogResults(response, results);
            });
        }
    }
}
