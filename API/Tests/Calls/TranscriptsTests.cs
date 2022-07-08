using NUnit.Allure.Core;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    [TestFixture]
    [AllureNUnit]
    public class TranscriptsTests : BaseApiTest
    {
        [TestCase("0008f126-1b08-4a07-8efb-7ddf3e50549c", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Transcripts_GET_200")]
        public async Task Transcripts(string jobId, ResponseStatus status, HttpStatusCode code)
        {
            if (jobId.Equals(String.Empty))
            {
                jobId = base.callJobId;
            }

            RestRequest request = new RestRequest(CallsEndpoints.GetTranscriptsEndpoint(jobId), Method.Get);

            RestResponse<Transcripts> response = await callsClient.ExecuteAsync<Transcripts>(request);

            Transcripts transcripts = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }
    }
}
