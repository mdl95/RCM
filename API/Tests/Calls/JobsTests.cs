using Automation.API.Models.Calls;
using FluentValidation.Results;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RCM.API.Validators.Calls;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Calls
{
    public class JobsTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_GET_AllJobs_200"), Order(10)]
        public async Task Jobs_AllJobs(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(CallsEndpoints.GetJobsEndpoint(), Method.Get);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);
            
            Job jobData = response.Data;

            JobValidator validator = new JobValidator();
            ValidationResult results = validator.Validate(jobData);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                Assert.That(results.IsValid, Is.True);

                LogResults(response, results);
            });
        }


        [TestCase(TestName = "API_Calls_Jobs_GET_AllJobs_LimitAndOffset_200"), Ignore("Implement")]
        public async Task Jobs_AllJobs_LimitAndOffset() { }


        [TestCase(TestName = "API_Calls_Jobs_GET_AllJobs_Filter_200"), Ignore("Implement")]
        public async Task Jobs_AllJobs_Filter() { }


        [TestCase(TestName = "API_Calls_Jobs_GET_AllJobs_Sort_200"), Ignore("Implement")]
        public async Task Jobs_AllJobs_Sort() { }


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_POST_200"), Order(20)]
        public async Task Jobs_POST(ResponseStatus status, HttpStatusCode code)
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
        public async Task Jobs_GET(string callJobId, ResponseStatus status, HttpStatusCode code)
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


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Calls_Jobs_PUT_200"), Order(40)]
        public async Task Jobs_PUT(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            Input inputs = new Input
            {
                Claim_ClaimDateOfService = "2022-01-01T00:00:00.000Z",
                PatientDateOfBirth = "1950-01-01T00:00:00.000Z",
                PatientMemberId = "UpdatedAutoCalls123",
                CallInformationTaxId = "123-45-6789"
            };

            JobData payload = new JobData
            {
                Type = "Mock",
                PhoneNumber = "+16788843304",
                Inputs = inputs
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetJobsCallbacksEndpoint(callJobId), Method.Put)
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
    }
}
