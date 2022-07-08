using RCM.API.Support;

namespace RCM.API.Endpoints
{
    public static class CallsEndpoints
    {
        // Jobs

        public static string GetJobsEndpoint() =>
            $"{Config.BASE_URN}/jobs";

        public static string GetJobs_LimitAndOffset_Endpoint(int limit, long offset) =>
            $"{Config.BASE_URN}/jobs?limit={limit}&offset={offset}";

        public static string GetJobs_Filter_Endpoint(string filters) =>
            $"{Config.BASE_URN}/jobs?filter={filters}";

        public static string GetJobs_Sort_Endpoint(string sort) =>
            $"{Config.BASE_URN}/jobs?sort={sort}";

        public static string GetJobEndpoint(string id) =>
            $"{Config.BASE_URN}/jobs/{id}";

        public static string GetJobsCallbacksEndpoint(string id) =>
            $"{Config.BASE_URN}/jobs/{id}/callbacks";


        // Recording

        public static string GetRecordingEndpoint(string jobId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/recording";


        // Transcripts

        public static string GetTranscriptsEndpoint(string jobId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts";

        public static string GetTranscripts_LimitAndOffset_Endpoint(string jobId, int limit, long offset) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts?limit={limit}&offset={offset}";

        public static string GetTranscripts_Filters_Endpoint(string jobId, string filters) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts?filters={filters}";

        public static string GetTranscripts_Sorts_Endpoint(string jobId, string sorts) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts?sorts={sorts}";
    }
}
