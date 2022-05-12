using RCM.API.Support;

namespace RCM.API.Endpoints
{
    public static class IvrAgentBotEndpoints
    {
        // Status

        public static string GetStatusEndpoint() =>
            $"{Config.BASE_URN}/status";


        // Transcript

        public static string GetTranscriptEndpoint() =>
            $"{Config.BASE_URN}/replyto/call-transcript-clause";


        // Version

        public static string GetVersionEndpoint() =>
            $"{Config.BASE_URN}/version";
    }
}
