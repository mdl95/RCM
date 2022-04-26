using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class CallStatusCallbacksTests : BaseApiTest
    {
        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_CallStatusCallbacks_POST_200")]
        [TestCase("badJobID12345", ResponseStatus.Error, HttpStatusCode.BadRequest, TestName = "API_Calls_CallStatusCallbacks_POST_BadJobID_400")]
        public async Task API_Calls_CallStatusCallbacks_POST(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            CallStatusCallback payload = new CallStatusCallback
            {
                AccountSid = "AutoAccountSID",
                CallSid = "AutoCallSID",
                From = "AutoFrom",
                To = "AutoTo",
                CallStatus = "",
                ApiVersion = "AutoAPIVersion",
                Direction = "AutoDirection",
                ForwardedFrom = "AutoForwardedFrom",
                CallerName = "AutoCallerName",
                ParentCallSid = "AutoParentCallSID",
                CallDuration = "AutoCallDuration",
                SipResponseCode = "AutoSIPResponseCode",
                RecordingUrl = "AutoRecordingURL",
                RecordingSid = "AutoRecordingSID",
                RecordingDuration = "AutoRecordingDuration",
                Timestamp = "AutoTimestamp",
                CallbackSource = "AutoCallbackSource",
                SequenceNumber = "AutoSequenceNumber"
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetCallStatusEndpoint(callJobId), Method.Post)
                .AddJsonBody(payload);

            RestResponse<CallStatusCallback> response = await callsClient.ExecuteAsync<CallStatusCallback>(request);

            CallStatusCallback callStatusCallback = response.Data;

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
