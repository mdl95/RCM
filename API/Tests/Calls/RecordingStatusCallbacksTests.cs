using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class RecordingStatusCallbacksTests : BaseApiTest
    {
        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_RecordingStatusCallbacks_200")]
        public async Task RecordingStatusCallbacks(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            RecordingStatusCallback payload = new RecordingStatusCallback
            {
                AccountSid = "AutoAccount",
                CallSid = "AutoCallSID",
                RecordingSid = "AutoRecordingSID",
                RecordingUrl = "AutoRecordingURL",
                RecordingStatus = "AutoRecordingStatus",
                RecordingDuration = "AutoRecordingDuration",
                RecordingChannels = "AutoRecordingChannels",
                RecordingStartTime = "AutoRecordingStartTime",
                RecordingSource = "AutoRecordingSource",
                RecordingTrack = "AutoRecordingTrack"
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetRecordingStatusCallbacksEndpoint(callJobId), Method.Post)
                .AddJsonBody(payload);

            RestResponse<RecordingStatusCallback> response = await callsClient.ExecuteAsync<RecordingStatusCallback>(request);

            RecordingStatusCallback callStatusCallbackData = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(TestName = "API_Calls_RecordingStatusCallbacks_ConversationId_POST_200"), Ignore("Implement")]
        public async Task RecordingStatusCallbacks_ConversationId()
        {
        }


        [TestCase(TestName = "API_Calls_RecordingStatusCallbacks_ParticipantId_POST_200"), Ignore("Implement")]
        public async Task RecordingStatusCallbacks_ParticipantId()
        {
        }
    }
}
