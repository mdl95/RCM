using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Claims;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Claims
{
    public class EntityBagTests : BaseApiTest
    {
        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_EntityBagClaimHistory_GET_200"), Order(0)]
        public async Task API_Claims_EntityBagClaimHistory_GET(string oaiClaimId, ResponseStatus status, HttpStatusCode code)
        {
            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimEntityBag_ClaimHistory_Endpoint(oaiClaimId), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;
            entityBagId = entityBag.Data[0].EntityBagId; // Set global entityBagId

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_EntityBag_GET_AllEntityBags_200")]
        public async Task API_Claims_EntityBag_GET_AllEntityBags(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntityBagsEndpoint(), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_EntityBag_GET_AllEntityBags_LimitAndOffset_200")]
        public async Task API_Claims_EntityBag_GET_AllEntityBags_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntityBags_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(entityBag.Limit, Is.EqualTo(limit));
                Assert.That(entityBag.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(entityBag.Offset, Is.EqualTo(offset));
            });
        }


        [TestCase("entityBagId", "=", "25b1c09a-ea7a-4b6c-bbe6-8d15d7d19998", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_EntityBag_GET_AllEntityBags_Filter_200")]
        public async Task API_Claims_EntityBag_GET_AllEntityBags_Filter(string path, string op, string value, ResponseStatus status, HttpStatusCode code)
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntityBags_Filter_Endpoint(filter), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                //TODO: Filter assertion
            });
        }


        [TestCase("entityBagId", false, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_EntityBag_GET_AllEntityBags_Sort_200")]
        public async Task API_Claims_EntityBag_GET_AllEntityBags_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code)
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntityBags_Sort_Endpoint(sort), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < entityBag.Data[0].EntityVersions.Count; ++i)
                {
                    Assert.That(entityBag.Data[0].EntityVersions[i].Established.Created,
                        Is.GreaterThanOrEqualTo(entityBag.Data[0].EntityVersions[i - 1].Established.Created));
                }
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_EntityBag_GET_200")]
        public async Task API_Claims_EntityBag_GET(string entityBagId, ResponseStatus status, HttpStatusCode code)
        {
            if (entityBagId.Equals(String.Empty))
            {
                entityBagId = base.entityBagId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntityBagEndpoint(entityBagId), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 0; i < entityBag.EntityVersions.Count; ++i)
                {
                    Assert.That(entityBag.EntityVersions[i].Established.EntityBagId, Is.EqualTo(entityBagId));
                }
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_200")]
        public async Task API_Claims_ClaimEntityBag_GET_AllClaimEntityBags(string oaiClaimId, ResponseStatus status, HttpStatusCode code)
        {
            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimEntityBagsEndpoint(oaiClaimId), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 0; i < entityBag.Data.Count; ++i)
                {
                    Assert.That(entityBag.Data[i].CallJob.Data[0].OaiClaimId, Is.EqualTo(oaiClaimId));
                }
            });
        }


        [TestCase("", 5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_LimitAndOffset_200")]
        public async Task API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_LimitAndOffset(string oaiClaimId, int limit, long offset, ResponseStatus status, HttpStatusCode code)
        {
            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimEntityBags_LimitAndOffset_Endpoint(oaiClaimId, limit, offset), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(entityBag.Limit, Is.EqualTo(limit));
                Assert.That(entityBag.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(entityBag.Offset, Is.EqualTo(offset));
            });
        }


        [TestCase("", "entityBagId", "=", "25b1c09a-ea7a-4b6c-bbe6-8d15d7d19998", ResponseStatus.Completed, HttpStatusCode.OK,
            TestName = "API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_Filter_200")]
        public async Task API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_Filter(string oaiClaimId, string path, string op, string value, ResponseStatus status, HttpStatusCode code)
        {
            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimEntityBags_Filter_Endpoint(oaiClaimId, filter), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                //TODO: Filter Assert
            });
        }


        [TestCase("", "created", true, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_Sort_200")]
        public async Task API_Claims_ClaimEntityBag_GET_AllClaimEntityBags_Sort(string oaiClaimId, string path, bool descending, ResponseStatus status, HttpStatusCode code)
        {
            if (oaiClaimId.Equals(String.Empty))
            {
                oaiClaimId = base.oaiClaimId;
            }

            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetOaiClaimEntityBags_Sort_Endpoint(oaiClaimId, sort), Method.Get);

            RestResponse<EntityBag> response = await claimsClient.ExecuteAsync<EntityBag>(request);

            EntityBag entityBag = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < entityBag.Data[0].EntityVersions.Count; ++i)
                {
                    Assert.That(entityBag.Data[0].EntityVersions[i].Established.Created,
                        Is.GreaterThanOrEqualTo(entityBag.Data[0].EntityVersions[i - 1].Established.Created));
                }
            });
        }
    }
}
