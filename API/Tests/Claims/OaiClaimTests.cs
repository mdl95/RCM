using Newtonsoft.Json;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Claims;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Claims
{
    public class OaiClaimTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_AllOaiClaims_200")]
        public async Task API_Claims_OaiClaim_GET_AllOaiClaims(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimsEndpoint(), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);
            
            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_AllOaiClaims_LimitAndOffset_200")]
        public async Task API_Claims_OaiClaim_GET_AllOaiClaims_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code) 
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaims_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(oaiClaim.Limit, Is.EqualTo(limit));
                Assert.That(oaiClaim.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(oaiClaim.Offset, Is.EqualTo(offset));
            });
        }


        [TestCase("insurerName", "=", "InsName-BYB", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_AllOaiClaims_Filter_200")]
        public async Task API_Claims_OaiClaim_GET_AllOaiClaims_Filter(string path, string op, string value, ResponseStatus status, HttpStatusCode code) 
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaims_Filter_Endpoint(filter), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 0; i < oaiClaim.Data.Count; ++i)
                {
                    Assert.That(oaiClaim.Data[i].InsurerName, Is.EqualTo(value));
                }
            });
        }


        [TestCase("created", false, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_AllOaiClaims_Sort_200")]
        public async Task API_Claims_OaiClaim_GET_AllOaiClaims_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code) 
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaims_Sort_Endpoint(sort), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < oaiClaim.Data.Count; ++i)
                {
                    Assert.That(DateTime.Parse(oaiClaim.Data[i].Created),
                        Is.GreaterThanOrEqualTo(DateTime.Parse(oaiClaim.Data[i - 1].Created)));
                }
            });
        }


        [TestCase("00160a72-9b4f-4a4f-a6f4-87394fd93dd8", "854fe1df-68b6-48c5-8060-8b5f6c355b99", "pending", 
            "23e90309-70d8-4415-9924-5b69fdd1c029", "Riley Nkosi", "945e284b-12cd-4774-93e5-7c3352094555", 
            "OK: phone with garbage", TestName = "API_Claims_OaiClaim_PATCH_200")]
        public async Task API_Claims_OaiClaim_PATCH(string oaiClaimId, string entityId, string entityValue, string actorId, string actorName, string activityId, string remarks)
        {
            if (entityId.Equals(String.Empty))
            {
                entityId = base.entityId;
            }

            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            Entity entity = new Entity
            {
                EntityId = entityId
            };

            List<EntityVersion> entityVersion = new List<EntityVersion>();
            entityVersion.Add(new EntityVersion
            {
                Entity = entity,
                EntityValue = entityValue
            });

            OaiClaim payload = new OaiClaim
            {
                EntityVersions = entityVersion,
                ActorId = actorId,
                ActorName = actorName,
                ActivityId = activityId,
                Remarks = remarks,
            };

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimEndpoint(oaiClaimId), Method.Patch)
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(payload);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaimData = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_200")]
        public async Task API_Claims_OaiClaim_GET(string oaiClaimId, ResponseStatus status, HttpStatusCode code)
        {
            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimEndpoint(oaiClaimId), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_CountStatus_200")]
        public async Task API_Claims_OaiClaim_GET_CountStatus(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_CountStatus_Endpoint(), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_CountStatus_LimitAndOffset_200")]
        public async Task API_Claims_OaiClaim_GET_CountStatus_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code) 
        {
            int totalCount = 0;

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_CountStatus_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = JsonConvert.DeserializeObject<OaiClaim>(response.Content);

            LogResults(response);

            for (int i = 0; i < oaiClaim.Occurrences.Count; ++i)
            {
                totalCount += oaiClaim.Occurrences[i].Count;
            }

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(oaiClaim.Count, Is.EqualTo(totalCount));
            });
        }


        [TestCase("insurerName", "=", "InsName-BYB", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_CountStatus_Filter_200")]
        public async Task API_Claims_OaiClaim_GET_CountStatus_Filter(string path, string op, string value, ResponseStatus status, HttpStatusCode code) 
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_CountStatus_Filter_Endpoint(filter), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = JsonConvert.DeserializeObject<OaiClaim>(response.Content);

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase("count", false, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_CountStatus_Sort_200")]
        public async Task API_Claims_OaiClaim_GET_CountStatus_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code) 
        {
            var sort = SetSort(path, descending);
            int totalCount = 0;

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_CountStatus_Sort_Endpoint(sort), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);
            
            OaiClaim oaiClaim = JsonConvert.DeserializeObject<OaiClaim>(response.Content);

            LogResults(response);

            for (int i = 0; i < oaiClaim.Occurrences.Count; ++i)
            {
                totalCount += oaiClaim.Occurrences[i].Count;
            }

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(oaiClaim.Count, Is.EqualTo(totalCount));

                for (int i = 1; i < oaiClaim.Occurrences.Count; ++i)
                {
                    Assert.That(oaiClaim.Occurrences[i].Count, Is.GreaterThanOrEqualTo(oaiClaim.Occurrences[i - 1].Count));
                }
            });
        }


        [TestCase("InsurerName", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_UniqueFieldCount_200")]
        public async Task API_Claims_OaiClaim_GET_UniqueFieldCount(string field, ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_UniqueFieldCount_Endpoint(field), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(5, 0, "InsurerName", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_UniqueFieldCount_LimitAndOffset_200")]
        public async Task API_Claims_OaiClaim_GET_UniqueFieldCount_LimitAndOffset(int limit, long offset, string field, ResponseStatus status, HttpStatusCode code) 
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_UniqueFieldCount_LimitAndOffset_Endpoint(field, limit, offset), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);
            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(oaiClaim.Limit, Is.EqualTo(limit));
                Assert.That(oaiClaim.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(oaiClaim.Offset, Is.EqualTo(offset));
            });
        }


        [TestCase("group", "=", "owner", "patientId", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_UniqueFieldCount_Filter_200")]
        public async Task API_Claims_OaiClaim_GET_UniqueFieldCount_Filter(string path, string op, string value, string field, ResponseStatus status, HttpStatusCode code) 
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_UniqueFieldCount_Filter_Endpoint(field, filter), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);
            OaiClaim oaiClaim = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase("count", true, "patientId", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_OaiClaim_GET_UniqueFieldCount_Sort_200")]
        public async Task API_Claims_OaiClaim_GET_UniqueFieldCount_Sort(string path, bool descending, string field, ResponseStatus status, HttpStatusCode code) 
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaim_UniqueFieldCount_Sort_Endpoint(field, sort), Method.Get);

            RestResponse<OaiClaim> response = await claimsClient.ExecuteAsync<OaiClaim>(request);

            OaiClaim oaiClaim = JsonConvert.DeserializeObject<OaiClaim>(response.Content);

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < oaiClaim.Data.Count; ++i)
                {
                    Assert.That(oaiClaim.Count, Is.LessThanOrEqualTo(oaiClaim.Count));
                    //Assert.That(oaiClaim.Data[i].Group, Is.LessThanOrEqualTo(oaiClaim.Data[i - 1].Group));
                }
            });
        }
    }
}
