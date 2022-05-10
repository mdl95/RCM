using Automation.API.Models.Calls;
using Newtonsoft.Json;
using NUnit.Framework;
using RCM.API.Endpoints;
using RCM.API.Models.Calls;
using RCM.API.Models.Claims;
using RCM.API.Support;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RCM.API.Tests
{
    public abstract class BaseApiTest
    {
        protected RestClient claimsClient;
        protected RestClient callsClient;
        protected RestClient eventClient;


        /*
         * Various IDs needed by the tests
         * These IDs are generated when tests begin to run in order to avoid 
         * hard-coding IDs that may/may not exist in the DB
         */
        protected string callJobId;
        protected string csvClaimId;
        protected string csvImportId;
        protected string entityId;
        protected string entityBagId;
        protected string oaiClaimId;


        [OneTimeSetUp]
        public async Task Setup()
        {
            SetupClients();

            const string GOOD_FILE = "Random-20Rows.csv";
            string path = $"{GetSolutionDirectory()}\\API\\ClaimImportFiles\\{GOOD_FILE}";

            RestRequest request = new RestRequest(ClaimsEndpoints.GetCsvImportEndpoint(), Method.Post);
            request.AlwaysMultipartFormData = true;
            request.AddHeader("Content-Type", "multipart/form-data");

            byte[] bytesFile = File.ReadAllBytes(path);
            request.AddFile("formFile", bytesFile, path, "text/csv");

            RestResponse<CsvImportData> response = await claimsClient.ExecuteAsync<CsvImportData>(request);

            CsvImportData csvImportData = response.Data;
            List<CsvClaimData> csvClaimData = csvImportData.CsvClaims;

            string jobId = await SetJobIdAsync();
            callJobId = jobId; // Set global callJobId

            SetClaimsIds(csvImportData);
        }


        protected void LogResults(RestResponse response)
        {
            if (response != null)
            {
                Console.WriteLine();
                Console.WriteLine($"           Test: {TestContext.CurrentContext.Test.Name}");
                Console.WriteLine($"Response Status: {response.ResponseStatus}");

                if (response.ErrorMessage != null)
                {
                    Console.WriteLine($"  Error Message: {response.ErrorMessage}");
                }

                Console.WriteLine($"    Status Code: {(int)response.StatusCode} - {response.StatusCode}");
                //Console.WriteLine($"\nResponse Body: \n{PrettifyJson(response.Content)}");
            }
            else
            {
                Console.WriteLine("'response' was NULL");
            }
        }

        protected async Task<string> SetJobIdAsync()
        {
            string jobId;

            Input inputs = new Input
            {
                Claim_ClaimDateOfService = "2000-01-01T00:00:00.000Z",
                Patient_DateOfBirth = "2000-01-01T00:00:00.000Z",
                Patient_MemberId = "AutoCalls123",
                CallInformation_TaxId = "123-45-6789"
            };

            Job job = new Job
            {
                Type = "Mock",
                PhoneNumber = "+14045555555",
                Inputs = inputs
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetJobsEndpoint(), Method.Post);
            request.AddJsonBody(job);

            RestResponse<Job> response = await callsClient.ExecuteAsync<Job>(request);

            Job jobData = response.Data;

            jobId = jobData.Id;

            return jobId;
        }

        protected void SetClaimsIds(CsvImportData csvImportData)
        {
            List<CsvClaimData> csvClaimData = csvImportData.CsvClaims;

            csvImportId = csvImportData.Id; // Set global csvImportId
            csvClaimId = csvClaimData[0].CsvClaimId; // Set global csvClaimId
            oaiClaimId = csvClaimData[0].OaiClaimId; // Set global oaiClaimId
        }

        protected string SetFilter(string path, string op, string value) 
        {
            var filter = new
            {
                Path = path,
                Operator = op,
                Value = value
            };

            string serializedFilter = System.Text.Json.JsonSerializer.Serialize(filter);
            return serializedFilter;
        }

        protected string SetFilter(string path, string op, int value)
        {
            var filter = new
            {
                Path = path,
                Operator = op,
                Value = value.ToString()
            };

            string serializedFilter = System.Text.Json.JsonSerializer.Serialize(filter);
            return serializedFilter;
        }


        protected string SetSort(string path, bool descending) 
        {
            var sort = new
            {
                Path = path,
                Descending = descending
            };

            string serializedSort = System.Text.Json.JsonSerializer.Serialize(sort);
            return serializedSort;
        }

        protected string GetSolutionDirectory()
        {
            string solutionPath = Directory.GetCurrentDirectory();
            return solutionPath;
        }


        private void SetupClients()
        {
            callsClient = new RestClient(Config.CALLS_BASE_URL);
            claimsClient = new RestClient(Config.CLAIMS_BASE_URL);
            eventClient = new RestClient(Config.EVENTS_BASE_URL);
        }


        private string PrettifyJson(string json)
        {
            string prettifiedJson;

            if (json != null)
            {
                using (StringReader stringReader = new StringReader(json))
                using (StringWriter stringWriter = new StringWriter())
                {
                    JsonTextReader jsonReader = new JsonTextReader(stringReader);
                    JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter)
                    {
                        Formatting = Formatting.Indented
                    };
                    
                    jsonWriter.WriteToken(jsonReader);                    
                    prettifiedJson = stringWriter.ToString();
                }
            }
            else
            {
                Console.WriteLine("'json' was NULL - check the Response");
                prettifiedJson = "";
            }

            return prettifiedJson;
        }
    }
}
