using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Claims;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RCM.API.Tests.Claims
{
    public class CsvImportTests : BaseApiTest
    {
        [TestCase(false, "Random-20Rows.csv", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvImport_POST_200")]
        [TestCase(false, "Random-BadDate.csv", ResponseStatus.Error, HttpStatusCode.BadRequest, TestName = "API_Claims_CsvImport_POST_BadDate_400")]
        [TestCase(false, "Random-4Rows-2Malformed.csv", ResponseStatus.Error, HttpStatusCode.BadRequest, TestName = "API_Claims_CsvImport_POST_Malformed_400")]
        [TestCase(false, "Random-5Rows-3BadField.csv", ResponseStatus.Error, HttpStatusCode.BadRequest, TestName = "API_Claims_CsvImport_POST_BadField_400")]
        public async Task CsvImport(bool startUnattendedCalls, string csvFile, ResponseStatus status, HttpStatusCode code)
        {
            string path = $"{GetSolutionDirectory()}\\API\\ClaimImportFiles\\{csvFile}";

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvImportEndpoint(), Method.Post);
            request.AlwaysMultipartFormData = true;
            request.AddHeader("Content-Type", "multipart/form-data");

            byte[] bytesFile = File.ReadAllBytes(path);
            request.AddFile("formFile", bytesFile, path, "text/csv");

            RestResponse<CsvImportData> response = await claimsClient.ExecuteAsync<CsvImportData>(request);

            CsvImportData csvImportData = response.Data;
            List<CsvClaimData> csvClaimData = csvImportData.CsvClaims;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvImport_GET_AllImports_200")]
        public async Task CsvImport_AllImports(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvImportsEndpoint(), Method.Get);

            RestResponse<CsvImport> response = await claimsClient.ExecuteAsync<CsvImport>(request);

            CsvImport csvImport = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }


        [TestCase(5, 0, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvImport_GET_AllImports_LimitAndOffset_200")]
        public async Task CsvImport_AllImports_LimitAndOffset(int limit, long offset, ResponseStatus status, HttpStatusCode code) 
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvImports_LimitAndOffset_Endpoint(limit, offset), Method.Get);

            RestResponse<CsvImport> response = await claimsClient.ExecuteAsync<CsvImport>(request);

            CsvImport csvImport = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
                Assert.That(csvImport.Limit, Is.EqualTo(limit));
                Assert.That(csvImport.Data.Count, Is.LessThanOrEqualTo(limit));
                Assert.That(csvImport.Offset, Is.EqualTo(offset));
            });
        }


        [TestCase("id", "=", "", ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvImport_GET_AllImports_Filter_200")]
        public async Task CsvImport_AllImports_Filter(string path, string op, string value, ResponseStatus status, HttpStatusCode code) 
        {
            if (value.Equals(String.Empty))
            {
                value = csvImportId;
            }

            var filter = SetFilter(path, op, value);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvImports_Filter_Endpoint(filter), Method.Get);

            RestResponse<CsvImport> response = await claimsClient.ExecuteAsync<CsvImport>(request);

            CsvImport csvImport = response.Data;
            List<CsvImportData> csvImportData = csvImport.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 0; i < csvImportData.Count; i++)
                {
                    Assert.That(csvImportData[i].Id, Is.EqualTo(value));
                }
            });
        }


        [TestCase("created", false, ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvImport_GET_AllImports_Sort_200")]
        public async Task CsvImport_AllImports_Sort(string path, bool descending, ResponseStatus status, HttpStatusCode code) 
        {
            var sort = SetSort(path, descending);

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvImports_Sort_Endpoint(sort), Method.Get);

            RestResponse<CsvImport> response = await claimsClient.ExecuteAsync<CsvImport>(request);

            CsvImport csvImport = response.Data;
            List<CsvImportData> csvImportData = csvImport.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));

                for (int i = 1; i < csvImportData.Count; i++)
                {
                    Assert.That(csvImportData[i].Created, Is.GreaterThanOrEqualTo(csvImportData[i - 1].Created));
                }
            });
        }


        [TestCase(ResponseStatus.Completed, HttpStatusCode.OK, TestName = "API_Claims_CsvImport_GET_200")]
        public async Task CsvImport(ResponseStatus status, HttpStatusCode code)
        {
            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvImportEndpoint(csvImportId), Method.Get);

            RestResponse<CsvImportData> response = await claimsClient.ExecuteAsync<CsvImportData>(request);

            CsvImportData csvImportData = response.Data;

            LogResults(response);

            Assert.Multiple(() =>
            {
                Assert.That(response.ResponseStatus, Is.EqualTo(status));
                Assert.That(response.StatusCode, Is.EqualTo(code));
            });
        }
    }
}
