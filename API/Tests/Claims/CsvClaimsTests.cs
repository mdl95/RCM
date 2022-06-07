using FluentValidation.Results;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Claims;
using RCM.API.Validators.Claims;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Claims
{
    public class CsvClaimsTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvClaim_GET_AllClaims_200"), Order(0)]
        public async Task AllClaims(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvClaimEndpoint(), Method.Get);

            RestResponse<CsvClaim> response = await claimsClient.ExecuteAsync<CsvClaim>(request);

            CsvClaim csvClaim = response.Data;

            CsvClaimValidator validator = new CsvClaimValidator();
            ValidationResult results = validator.Validate(csvClaim);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                LogResults(response, results);
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvClaim_GET_AllClaims_LimitAndOffset_200")]
        public async Task AllClaims_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code) 
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvClaim_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse<CsvClaim> response = await claimsClient.ExecuteAsync<CsvClaim>(request);

            CsvClaim csvClaim = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(csvClaim.Limit, Is.EqualTo(limit));
                Assert.That(csvClaim.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(csvClaim.Offset, Is.EqualTo(offset));

                LogResults(response);
            });
        }


        [TestCase("patientId", "=", "YR.426968Y", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvClaim_GET_AllClaims_Filter_200")]
        public async Task AllClaims_Filter(string path, string op, string value, ResponseStatus status, HttpStatusCode code) 
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvClaim_Filter_Endpoint(filter), Method.Get);

            RestResponse<CsvClaim> response = await claimsClient.ExecuteAsync<CsvClaim>(request);

            CsvClaim csvClaim = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 0; i < csvClaim.Data.Count; ++i)
                {
                    Assert.That(csvClaim.Data[i].PatientId, Is.EqualTo(value));
                }

                LogResults(response);
            });
        }


        [TestCase("claimSubmissionDate", true, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvClaim_GET_AllClaims_Sort_200")]
        public async Task AllClaims_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code) 
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvClaim_Sort_Endpoint(sort), Method.Get);

            RestResponse<CsvClaim> response = await claimsClient.ExecuteAsync<CsvClaim>(request);

            CsvClaim csvClaim = response.Data;

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < csvClaim.Data.Count; ++i)
                {
                    Assert.That(DateTime.Parse(csvClaim.Data[i].ClaimSubmissionDate), 
                        Is.LessThanOrEqualTo(DateTime.Parse(csvClaim.Data[i - 1].ClaimSubmissionDate)));
                }

                LogResults(response);
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvClaim_GET_200")]
        public async Task Get(string csvClaimId, ResponseStatus status, HttpStatusCode code)
        {
            if (csvClaimId.Equals(String.Empty))
            {
                csvClaimId = base.csvClaimId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvClaimEndpoint(csvClaimId), Method.Get);

            RestResponse<CsvClaimData> response = await claimsClient.ExecuteAsync<CsvClaimData>(request);

            CsvClaimData csvClaimData = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(csvClaimData.CsvClaimId, Is.EqualTo(csvClaimId));
            });
        }
    }
}
