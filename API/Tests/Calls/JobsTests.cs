using Automation.API.Models.Jobs;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class JobsTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_AllJobs_200"), Order(10)]
        public async Task API_Calls_Jobs_GET_AllJobs(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(CallsEndpoints.GetJobsEndpoint(), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);
            
            Job job = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(TestName = "API_Calls_Jobs_GET_AllJobs_LimitAndOffset_200"), Ignore("Implement")]
        public async Task API_Calls_Jobs_GET_AllJobs_LimitAndOffset() { }


        [TestCase(TestName = "API_Calls_Jobs_GET_AllJobs_Filter_200"), Ignore("Implement")]
        public async Task API_Calls_Jobs_GET_AllJobs_Filter() { }


        [TestCase(TestName = "API_Calls_Jobs_GET_AllJobs_Sort_200"), Ignore("Implement")]
        public async Task API_Calls_Jobs_GET_AllJobs_Sort() { }


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_POST_200"), Order(20)]
        public async Task API_Calls_Jobs_POST(ResponseStatus status, HttpStatusCode code)
        {
            Input inputs = new Input
            {
                Claim_ClaimDateOfService = "2000-01-01T00:00:00.000Z",
                Patient_DateOfBirth = "2000-01-01T00:00:00.000Z",
                Patient_MemberId = "AutoCalls123",
                CallInformation_TaxId = "123-45-6789"
            };

            Job payload = new Job
            {
                Type = "Mock",
                PhoneNumber = "+16788843304",
                Inputs = inputs
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetJobsEndpoint(), Method.Post)
                .AddJsonBody(payload);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);

            Job jobData = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_Job_200"), Order(30)]
        public async Task API_Calls_Jobs_GET_Job(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            RestRequest request = new RestRequest(CallsEndpoints.GetJobEndpoint(callJobId), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);
            
            Job job = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_PUT_200"), Order(40)]
        public async Task API_Calls_Jobs_PUT(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            Input inputs = new Input
            {
                Claim_ClaimDateOfService = "2022-01-01T00:00:00.000Z",
                Patient_DateOfBirth = "1950-01-01T00:00:00.000Z",
                Patient_MemberId = "UpdatedAutoCalls123",
                CallInformation_TaxId = "123-45-6789"
            };

            Job payload = new Job
            {
                Type = "Mock",
                PhoneNumber = "+16788843304",
                Inputs = inputs
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetJobsCallbacksEndpoint(callJobId), Method.Put)
                .AddJsonBody(payload);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);

            Job jobData = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }
    }
}
