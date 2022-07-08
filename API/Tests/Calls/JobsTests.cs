using Automation.API.Models.Calls;
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
    public class JobsTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_AllJobs_200"), Order(10)]
        public async Task AllJobs(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(CallsEndpoints.GetJobsEndpoint(), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);
            
            Job jobData = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_AllJobs_LimitAndOffset_200")]
        public async Task AllJobs_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code) 
        {
            RestRequest request = new RestRequest(CallsEndpoints.GetJobs_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);

            Job job = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(job.Limit, Is.EqualTo(limit));
                Assert.That(job.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(job.Offset, Is.EqualTo(offset));

                LogResults(response);
            });
        }


        [TestCase("status", "=", "Complete", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_AllJobs_Filter_200")]
        public async Task AllJobs_Filter(string path, string op, string value, ResponseStatus status, HttpStatusCode code) 
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(CallsEndpoints.GetJobs_Filter_Endpoint(filter), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);

            Job job = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 0; i < job.Data.Count; ++i)
                {
                    Assert.That(job.Data[i].Status, Is.EqualTo(value));
                }

                LogResults(response);
            });
        }


        [TestCase("status", true, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_AllJobs_Sort_200")]
        public async Task AllJobs_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code) 
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(CallsEndpoints.GetJobs_Sort_Endpoint(sort), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);

            Job job = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < job.Data.Count; ++i)
                {
                    Assert.That(job.Data[i].Status,
                        Is.LessThanOrEqualTo(job.Data[i - 1].Status));
                }

                LogResults(response);
            });
        }


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_POST_200"), Order(20)]
        public async Task Post(ResponseStatus status, HttpStatusCode code)
        {
            Input inputs = new Input
            {
                Claim_ClaimDateOfService = "2000-01-01T00:00:00.000Z",
                PatientDateOfBirth = "2000-01-01T00:00:00.000Z",
                PatientMemberId = "AutoCalls123",
                CallInformationTaxId = "123-45-6789"
            };

            JobData payload = new JobData
            {
                Type = "Mock",
                PhoneNumber = "+16788843304",
                Inputs = inputs
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetJobsEndpoint(), Method.Post)
                .AddJsonBody(payload);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);

            Job jobData = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_Job_200"), Order(30)]
        public async Task Get(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            RestRequest request = new RestRequest(CallsEndpoints.GetJobEndpoint(callJobId), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);
            
            Job job = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response);
            });
        }
    }
}
