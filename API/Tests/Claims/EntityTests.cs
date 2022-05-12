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
    public class EntityTests : BaseApiTest
    {
        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_Entity_GET_AllEntities_200"), Order(0)]
        public async Task Entity_AllEntities(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntitiesEndpoint(), Method.Get);

            RestResponse response = await claimsClient.ExecuteAsync(request);

            List<Entity> entities = JsonConvert.DeserializeObject<List<Entity>>(response.Content);
            entityId = entities[0].EntityId; // Set global entityId

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_Entity_GET_AllEntities_LimitAndOffset_200")]
        public async Task Entity_AllEntities_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code) 
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntities_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse response = await claimsClient.ExecuteAsync(request);

            List<Entity> entities = JsonConvert.DeserializeObject<List<Entity>>(response.Content);
            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(entities.Count, Is.EqualTo(limit));
            });
        }


        [TestCase("slot", "=", "auth_id", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_Entity_GET_AllEntities_Filter_200")]
        public async Task Entity_AllEntities_Filter(string path, string op, string value, ResponseStatus status, HttpStatusCode code) 
        {
            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntities_Filter_Endpoint(filter), Method.Get);

            RestResponse response = await claimsClient.ExecuteAsync(request);

            List<Entity> entities = JsonConvert.DeserializeObject<List<Entity>>(response.Content);
            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(entities.Count, Is.EqualTo(1));
                Assert.That(entities[0].Slot, Is.EqualTo(value));
            });
        }


        [TestCase("slot", true, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_Entity_GET_AllEntities_Sort_200")]
        public async Task Entity_AllEntities_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code) 
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntities_Sort_Endpoint(sort), Method.Get);

            RestResponse response = await claimsClient.ExecuteAsync(request);

            List<Entity> entities = JsonConvert.DeserializeObject<List<Entity>>(response.Content);
            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < entities.Count; ++i)
                {
                    Assert.That(entities[i].Slot, Is.LessThanOrEqualTo(entities[i - 1].Slot));
                }
            });
        }


        [TestCase("", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Entity_GET_200")]
        public async Task Entity(string entityId, ResponseStatus status, HttpStatusCode code)
        {
            if (entityId.Equals(String.Empty))
            {
                entityId = base.entityId;
            }

            RestRequest request = new RestRequest(ClaimsEndpoints.GetEntityEndpoint(entityId), Method.Get);

            RestResponse response = await claimsClient.ExecuteAsync(request);

            Entity entity = JsonConvert.DeserializeObject<Entity>(response.Content);

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(entity.EntityId, Is.EqualTo(entityId));
            });
        }
    }
}
