using RCM.API.Support;

namespace RCM.API.Endpoints
{
    public static class CallsEndpoints
    {
        // BrowserWebSocket

        public static string GetBrowserWebSocketEndpoint(string jobId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/browser";


        // CallStatusCallbacks

        public static string GetCallStatusEndpoint(string jobId) => 
            $"{Config.BASE_URN}/jobs/{jobId}/callStatus";

        public static string GetCallStatusEndpointWithConversationid(string jobId, string conversationId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/callStatus?conversationId={conversationId}";

        public static string GetCallStatusEndpointWithParticipantId(string jobId, string participantId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/callStatus?participantId={participantId}";


        // Health

        public static string GetHealthEndpoint() => 
            $"{Config.BASE_URN}/health";


        // Jobs

        public static string GetJobsEndpoint() => 
            $"{Config.BASE_URN}/jobs";

        public static string GetJobsEndpointWithLimitAndOffset(int limit, long offset) => 
            $"{Config.BASE_URN}/jobs?limit={limit}&offset={offset}";

        public static string GetJobsEndpointWithFilter(string[] filter) => 
            $"{Config.BASE_URN}/jobs?filter={filter}";

        public static string GetJobsEndpointWithSort(string[] sort) => 
            $"{Config.BASE_URN}/jobs?sort={sort}";

        public static string GetJobEndpoint(string id) => 
            $"{Config.BASE_URN}/jobs/{id}";

        public static string GetJobsCallbacksEndpoint(string id) => 
            $"{Config.BASE_URN}/jobs/{id}/callbacks";


        // Recording

        public static string GetRecordingEndpoint(string jobId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/recording";


        // RecordingStatusCallbacks

        public static string GetRecordingStatusCallbacksEndpoint(string jobId) => 
            $"{Config.BASE_URN}/jobs/{jobId}/recordingStatus";

        public static string GetRecordingStatusCallbacksEndpointWithConversationid(string jobId, string conversationId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/recordingStatus?conversationId={conversationId}";

        public static string GetRecordingStatusCallbacksEndpointWithParticipantId(string jobId, string participantId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/recordingStatus?participantId={participantId}";


        // StreamCallback

        public static string GetStreamCallbackEndpoint(string jobId) => 
            $"{Config.BASE_URN}/jobs/{jobId}/mediaStream";


        // StreamStatusCallback

        public static string GetStreamStatusCallbackEndpoint(string jobId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/streamStatus";

        public static string GetStreamStatusCallbackEndpointWithConversationid(string jobId, string conversationId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/streamStatus?conversationId={conversationId}";

        public static string GetStreamStatusCallbackEndpointWithParticipantId(string jobId, string participantId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/streamStatus?participantId={participantId}";


        // Transcripts

        public static string GetTranscriptsEndpoint(string jobId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts";

        public static string GetTranscripts_LimitAndOffset_Endpoint(string jobId, int limit, long offset) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts?limit={limit}&offset={offset}";

        public static string GetTranscripts_Filters_Endpoint(string jobId, string filters) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts?filters={filters}";

        public static string GetTranscripts_Sorts_Endpoint(string jobId, string sorts) =>
            $"{Config.BASE_URN}/jobs/{jobId}/transcripts?sorts={sorts}";


        // Twiml

        public static string GetTwimlEndpoint(string jobId) => 
            $"{Config.BASE_URN}/jobs/{jobId}/twiml.xml";

        public static string GetTwimlEndpointWithConversationid(string jobId, string conversationId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/twiml.xml?conversationId={conversationId}";

        public static string GetTwimlEndpointWithParticipantId(string jobId, string participantId) =>
            $"{Config.BASE_URN}/jobs/{jobId}/twiml.xml?participantId={participantId}";
    }
}
