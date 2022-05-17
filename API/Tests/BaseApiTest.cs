using Automation.API.Models.Calls;
using FluentValidation.Results;
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
        // Be sure to initialize the client in SetupClients()

        protected RestClient claimsClient;
        protected RestClient callsClient;
        protected RestClient eventClient;
        protected RestClient agentClient;
        protected RestClient extractClient;


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


        protected void LogResults(RestResponse response, ValidationResult results = null)
        {
            if (response != null)
            {
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

            if (results is not null && results.Errors.Count != 0)
            {
                Console.WriteLine("\nSchema Validation Errors:\n");

                for (int i = 0; i < results.Errors.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}) {results.Errors[i]}");
                }
            }
        }

        protected async Task<string> SetJobIdAsync()
        {
            string jobId;

            Input inputs = new Input
            {
                Claim_ClaimDateOfService = "2000-01-01T00:00:00.000Z",
                PatientDateOfBirth = "2000-01-01T00:00:00.000Z",
                PatientMemberId = "AutoCalls123",
                CallInformationTaxId = "123-45-6789"
            };

            JobData job = new JobData
            {
                Type = "Mock",
                PhoneNumber = "+14045555555",
                Inputs = inputs
            };

            RestRequest request = new RestRequest(CallsEndpoints.GetJobsEndpoint(), Method.Post);
            request.AddJsonBody(job);

            RestResponse<JobData> response = await callsClient.ExecuteAsync<JobData>(request);

            JobData jobData = response.Data;

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
            callsClient = new RestClient(Config.CALLS_BASE_URL_DEV);
            claimsClient = new RestClient(Config.CLAIMS_BASE_URL_DEV);
            eventClient = new RestClient(Config.EVENTS_BASE_URL_DEV);
            agentClient = new RestClient(Config.IVR_AGENT_BOT_URL_DEV);
            extractClient = new RestClient(Config.IVR_INFO_EXTRACTOR_URL_DEV);
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
