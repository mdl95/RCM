using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Events;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.CallTranscriptEvent
{
    public class EventsTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_CallTranscriptEvent_Events_GET_200")]
        public async Task API_CallTranscriptEvent_GET(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(EventsEndpoints.GetEventsEndpoint(), Method.Get);

            RestResponse<Events> response = await eventClient.ExecuteAsync<Events>(request);

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }
    }
}
