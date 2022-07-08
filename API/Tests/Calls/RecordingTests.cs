using NUnit.Allure.Core;
using NUnit.Framework;
using RCM.API.Endpoints;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    [TestFixture]
    [AllureNUnit]
    public class RecordingTests : BaseApiTest
    {
        [TestCase("0008f126-1b08-4a07-8efb-7ddf3e50549c", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Recording_GET_200")]
        public async Task Recording(string jobId, ResponseStatus status, HttpStatusCode code)
        {
            if (jobId.Equals(String.Empty))
            {
                jobId = base.callJobId;
            }

            RestRequest request = new RestRequest(CallsEndpoints.GetRecordingEndpoint(jobId), Method.Get);

            RestResponse response = await callsClient.ExecuteAsync(request);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }
    }
}
