using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class StreamStatusCallbackTests : BaseApiTest
    {
        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_StreamStatusCallback_POST_200")]
        public async Task API_Calls_StreamStatusCallback_POST(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            StreamStatusCallback payload = new StreamStatusCallback
            {
                AccountSid = "AutoAccountSID",
                CallSid = "AutoCallSID",
                StreamSid = "AutoStreamSID",
                StreamName = "AutoStreamName",
                StreamEvent = "AutoStreamEvent",
                StreamError = "AutoStreamError",
                Timestamp = "AutoTimestamp"
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetStreamStatusCallbackEndpoint(callJobId), Method.Post)
                .AddJsonBody(payload);

            RestResponse<StreamStatusCallback> response = await callsClient.ExecuteAsync<StreamStatusCallback>(request);

            StreamStatusCallback callStatusCallback = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }

        [TestCase(TestName = "API_Calls_CallStatusCallbacks_ConversationId_POST_200"), Ignore("Implement")]
        public async Task API_Calls_CallStatusCallbacks_ConversationId_POST()
        {
        }

        [TestCase(TestName = "API_Calls_CallStatusCallbacks_ParticipantId_POST_200"), Ignore("Implement")]
        public async Task API_Calls_CallStatusCallbacks_ParticipantId_POST()
        {
        }
    }
}
