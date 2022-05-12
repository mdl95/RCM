using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class StreamCallbackTests : BaseApiTest
    {
        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_StreamCallback_GET_200")]
        public async Task StreamCallback(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            RestRequest request = new RestRequest(CallsEndpoints.GetStreamCallbackEndpoint(callJobId), Method.Get);

            RestResponse<StreamCallback> response = await callsClient.ExecuteAsync<StreamCallback>(request);

            StreamCallback callStatusCallback = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }
    }
}
