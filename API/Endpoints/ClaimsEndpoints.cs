using RCM.API.Support;

namespace RCM.API.Endpoints
{
    public static class ClaimsEndpoints
    {
        // CallJob

        public static string GetCallJobEndpoint() =>
            $"{Config.BASE_URN}/calljob";

        public static string GetCallJobEndpoint(string jobId) =>
            $"{Config.BASE_URN}/calljob/{jobId}";

        public static string GetCallJobsEndpoint() =>
            $"{Config.BASE_URN}/calljob";

        public static string GetCallJobs_LimitAndOffset_Endpoint(int limit, long offset) =>
            $"{Config.BASE_URN}/calljob?limit={limit}&offset={offset}";

        public static string GetCallJobs_Filters_Endpoint(string filters) =>
            $"{Config.BASE_URN}/calljob?filters={filters}";

        public static string GetCallJobs_Sorts_Endpoint(string sorts) =>
            $"{Config.BASE_URN}/calljob?sorts={sorts}";

        public static string GetOaiClaimCallJobEndpoint(string oaiClaimId) =>
            $"{Config.BASE_URN}/calljob/{oaiClaimId}";

        public static string GetWebhookCallJobEndpoint() =>
            $"{Config.BASE_URN}/calljob/status";


        // CsvClaim

        public static string GetCsvClaimEndpoint() => 
            $"{Config.BASE_URN}/csvclaim";

        public static string GetCsvClaim_Filter_Endpoint(string filters) => 
            $"{Config.BASE_URN}/csvclaim?filter={filters}";

        public static string GetCsvClaim_Sort_Endpoint(string sorts) => 
            $"{Config.BASE_URN}/csvclaim?sort={sorts}";

        public static string GetCsvClaim_LimitAndOffset_Endpoint(int limit, long offset) =>
            $"{Config.BASE_URN}/csvclaim?limit={limit}&offset={offset}";

        public static string GetCsvClaimEndpoint(string csvClaimId) => 
            $"{Config.BASE_URN}/csvclaim/{csvClaimId}";


        // CsvImport

        public static string GetCsvImportsEndpoint() => 
            $"{Config.BASE_URN}/csvimport";

        public static string GetCsvImports_LimitAndOffset_Endpoint(int limit, long offset) =>
            $"{Config.BASE_URN}/csvimport?limit={limit}&offset={offset}";

        public static string GetCsvImports_Filter_Endpoint(string filters) =>
            $"{Config.BASE_URN}/csvimport?filter={filters}";

        public static string GetCsvImports_Sort_Endpoint(string sorts) =>
            $"{Config.BASE_URN}/csvimport?sort={sorts}";

        public static string GetCsvImportEndpoint(bool startUnattendedCalls = false) => 
            $"{Config.BASE_URN}/csvimport?startUnattendedCalls={startUnattendedCalls}";

        public static string GetCsvImportEndpoint(string csvImportId) => 
            $"{Config.BASE_URN}/csvimport/{csvImportId}";


        // Entity

        public static string GetEntitiesEndpoint() => 
            $"{Config.BASE_URN}/entity";

        public static string GetEntities_LimitAndOffset_Endpoint(int limit, long offset) =>
            $"{Config.BASE_URN}/entity?limit={limit}&offset={offset}";

        public static string GetEntities_Filter_Endpoint(string filters) => 
            $"{Config.BASE_URN}/entity?filter={filters}";

        public static string GetEntities_Sort_Endpoint(string sorts) => 
            $"{Config.BASE_URN}/entity?sort={sorts}";

        public static string GetEntityEndpoint(string entityId) => 
            $"{Config.BASE_URN}/entity/{entityId}";


        // EntityBag

        public static string GetEntityBagsEndpoint() => 
            $"{Config.BASE_URN}/entitybag";

        public static string GetEntityBags_LimitAndOffset_Endpoint(int limit, long offset) => 
            $"{Config.BASE_URN}/entitybag?limit={limit}&offset={offset}";

        public static string GetEntityBags_Filter_Endpoint(string filters) =>
            $"{Config.BASE_URN}/entitybag?Filter={filters}";

        public static string GetEntityBags_Sort_Endpoint(string sorts) =>
            $"{Config.BASE_URN}/entitybag?Sort={sorts}";

        public static string GetEntityBagEndpoint(string entityBagId) => 
            $"{Config.BASE_URN}/entitybag/bagid/{entityBagId}";

        public static string GetOaiClaimEntityBagsEndpoint(string oaiClaimId) => 
            $"{Config.BASE_URN}/entitybag/claim/{oaiClaimId}";

        public static string GetOaiClaimEntityBags_LimitAndOffset_Endpoint(string oaiClaimId, int limit, long offset) =>
            $"{Config.BASE_URN}/entitybag/claim/{oaiClaimId}?limit={limit}&offset={offset}";

        public static string GetOaiClaimEntityBags_Filter_Endpoint(string oaiClaimId, string filters) =>
            $"{Config.BASE_URN}/entitybag/claim/{oaiClaimId}?Filter={filters}";

        public static string GetOaiClaimEntityBags_Sort_Endpoint(string oaiClaimId, string sorts) =>
            $"{Config.BASE_URN}/entitybag/claim/{oaiClaimId}?Sort={sorts}";

        public static string GetOaiClaimEntityBag_ClaimHistory_Endpoint(string oaiClaimId) =>
            $"{Config.BASE_URN}/entitybag/claimhistory/{oaiClaimId}";
 

        // Health

        public static string GetHealthEndpoint() => 
            $"{Config.BASE_URN}​​/health";


        // OaiClaim

        public static string GetOaiClaimsEndpoint() => 
            $"{Config.BASE_URN}/oaiclaim";

        public static string GetOaiClaims_LimitAndOffset_Endpoint(int limit, long offset) =>
            $"{Config.BASE_URN}/oaiclaim?limit={limit}&offset={offset}";

        public static string GetOaiClaims_Filter_Endpoint(string filters) => 
            $"{Config.BASE_URN}/oaiclaim?filter={filters}";

        public static string GetOaiClaims_Sort_Endpoint(string sorts) => 
            $"{Config.BASE_URN}/oaiclaim?sort={sorts}";

        public static string GetOaiClaimEndpoint(string oaiClaimId) => 
            $"{Config.BASE_URN}/oaiclaim/{oaiClaimId}";

        public static string GetOaiClaim_CountStatus_Endpoint() => 
            $"{Config.BASE_URN}/oaiclaim/countStatus";

        public static string GetOaiClaim_CountStatus_LimitAndOffset_Endpoint(int limit, long offset) =>
            $"{Config.BASE_URN}/oaiclaim/countStatus?limit={limit}&offset={offset}";

        public static string GetOaiClaim_CountStatus_Filter_Endpoint(string filters) => 
            $"{Config.BASE_URN}/oaiclaim/countStatus?filter={filters}";

        public static string GetOaiClaim_CountStatus_Sort_Endpoint(string sorts) =>
            $"{Config.BASE_URN}/oaiclaim/countStatus?sort={sorts}";

        public static string GetOaiClaim_UniqueFieldCount_Endpoint(string field) => 
            $"{Config.BASE_URN}/oaiclaim/unique?field={field}";

        public static string GetOaiClaim_UniqueFieldCount_LimitAndOffset_Endpoint(string field, int limit, long offset) =>
            $"{Config.BASE_URN}/oaiclaim/unique?field={field}&limit={limit}&offset={offset}";

        public static string GetOaiClaim_UniqueFieldCount_Filter_Endpoint(string field, string filters) =>
            $"{Config.BASE_URN}/oaiclaim/unique?field={field}&filters={filters}";

        public static string GetOaiClaim_UniqueFieldCount_Sort_Endpoint(string field, string sorts) =>
            $"{Config.BASE_URN}/oaiclaim/unique?field={field}&sort={sorts}";
    }
}
