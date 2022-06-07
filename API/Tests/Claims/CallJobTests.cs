using Automation.API.Models.Calls;
using FluentValidation.Results;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RCM.API.Models.Claims;
using RCM.API.Validators.Calls;
using RCM.API.Validators.Claims;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Claims
{
    public class CallJobTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_GET_AllCallJobs_200"), Order(0)]
        public async Task AllCallJobs(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetCallJobsEndpoint(), Method.Get);

            RestResponse<CallJob> response = await claimsClient.ExecuteAsync<CallJob>(request);            

            CallJob callJob = response.Data;
            callJobId = callJob.Data[0].JobId;

            CallJobValidator validator = new CallJobValidator();
            ValidationResult results = validator.Validate(callJob);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response, results);
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_GET_AllCallJobs_LimitAndOffset_200")]
        public async Task AllCallJobs_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetCallJobs_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse<CallJob> response = await claimsClient.ExecuteAsync<CallJob>(request);

            CallJob callJob = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(callJob.Limit, Is.EqualTo(limit));
                Assert.That(callJob.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(callJob.Offset, Is.EqualTo(offset));

                LogResults(response);
            });
        }


        [TestCase("status", "=", 2, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_GET_AllCallJobs_Filter_200")]
        public async Task AllCallJobs_Filter(string path, string op, int value, ResponseStatus status, HttpStatusCode code)
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCallJobs_Filters_Endpoint(filter), Method.Get);

            RestResponse<CallJob> response = await claimsClient.ExecuteAsync<CallJob>(request);

            CallJob callJob = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 0; i < callJob.Data.Count; ++i)
                {
                    Assert.That(callJob.Data[i].Status, Is.EqualTo(value));
                }

                LogResults(response);
            });
        }


        [TestCase("jobId", true, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_GET_AllCallJobs_Sort_200")]
        [TestCase("jobId", false, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_GET_AllCallJobs_Sort_200")]
        public async Task AllCallJobs_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code)
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCallJobs_Sorts_Endpoint(sort), Method.Get);

            RestResponse<CallJob> response = await claimsClient.ExecuteAsync<CallJob>(request);

            CallJob callJob = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < callJob.Data.Count; ++i)
                {
                    if (descending == true)
                    {
                        Assert.That(callJob.Data[i].JobId, Is.LessThanOrEqualTo(callJob.Data[i - 1].JobId));
                    }
                    else
                    {
                        Assert.That(callJob.Data[i].JobId, Is.GreaterThanOrEqualTo(callJob.Data[i - 1].JobId));
                    }
                }

                LogResults(response);
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_GET_200"), Order(10)]
        public async Task Get(string callJobId, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCallJobEndpoint(this.callJobId), Method.Get);

            RestResponse<CallJobData> response = await claimsClient.ExecuteAsync<CallJobData>(request);

            CallJobData callJobData = response.Data;

            CallJobDataValidator validator = new CallJobDataValidator();
            ValidationResult results = validator.Validate(callJobData);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(callJobData.JobId, Is.EqualTo(callJobId));

                Assert.That(results.IsValid, Is.True);

                LogResults(response, results);
            });
        }


        [TestCase("", "API_Claims_CallJob_Patch_200 test notes...", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_PATCH_200")]
        public async Task Patch(string callJobId, string notes, ResponseStatus status, HttpStatusCode code)
        {
            if (callJobId.Equals(String.Empty))
            {
                callJobId = base.callJobId;
            }

            CallJob payload = new CallJob
            {
                JobId = callJobId,
                Notes = notes
            };

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCallJobsEndpoint(), Method.Patch)
                .AddJsonBody(payload);

            RestResponse<CallJobData> response = await claimsClient.ExecuteAsync<CallJobData>(request);

            CallJobData callJobData = response.Data;

            CallJobDataValidator validator = new CallJobDataValidator();
            ValidationResult results = validator.Validate(callJobData);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response, results);
            });
        }


        [TestCase("", "2000-01-01T00:00:00.000Z", "2000-01-01T00:00:00.000Z", "AutoCallJob123", "123-45-6789", "Mock", 
            "+16788843304", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_PUT_200")]
        public async Task Put(string oaiClaimId, string claimDateOfService, string patientDateOfBirth, 
            string patientMemberId, string callInfoTaxId, string type, string phoneNumber, ResponseStatus status, HttpStatusCode code)
        {
            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            Input inputs = new Input
            {
                Claim_ClaimDateOfService = claimDateOfService,
                PatientDateOfBirth = patientDateOfBirth,
                PatientMemberId = patientMemberId,
                CallInformationTaxId = callInfoTaxId
            };

            JobData payload = new JobData
            {
                Type = type,
                PhoneNumber = phoneNumber,
                Inputs = inputs
            };

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimCallJobEndpoint(this.oaiClaimId), Method.Put)
                .AddJsonBody(payload);

            RestResponse<CallJobData> response = await claimsClient.ExecuteAsync<CallJobData>(request);

            CallJobData callJobData = response.Data;

            CallJobDataValidator validator = new CallJobDataValidator();
            ValidationResult results = validator.Validate(callJobData);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(callJobData.OaiClaimId, Is.EqualTo(oaiClaimId));

                LogResults(response, results);
            });
        }


        [TestCase("2000-01-01T00:00:00.000Z", "2000-01-01T00:00:00.000Z", "AutoCallJob123", "123-45-6789",
            "02907772-b188-47ff-8056-007deb609274", "Mock", "Complete", "+16788843304", 
            ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CallJob_Status_PUT_200")]
        public async Task Status(string claimDateOfService, string patientDateOfBirth, string patientMemberId, 
            string callInfoTaxId, string id, string type, string status, string phoneNumber, ResponseStatus responseStatus, HttpStatusCode code)
        {
            Input inputs = new Input
            {
                Claim_ClaimDateOfService = claimDateOfService,
                PatientDateOfBirth = patientDateOfBirth,
                PatientMemberId = patientMemberId,
                CallInformationTaxId = callInfoTaxId
            };

            JobData payload = new JobData
            {
                Id = id,
                Type = type,
                Status = status,
                PhoneNumber = phoneNumber,
                Inputs = inputs
            };

            RestRequest request = new RestRequest(ClaimsEndpoints.GetWebhookCallJobEndpoint(), Method.Put)
                .AddJsonBody(payload);

            RestResponse<CallJobData> response = await claimsClient.ExecuteAsync<CallJobData>(request);

            CallJobData callJobData = response.Data;

            CallJobDataValidator validator = new CallJobDataValidator();
            ValidationResult results = validator.Validate(callJobData);

            LogResults(response, results);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(responseStatus));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response, results);
            });
        }
    }
}
