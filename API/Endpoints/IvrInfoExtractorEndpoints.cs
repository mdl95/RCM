using RCM.API.Support;

namespace RCM.API.Endpoints
{
    public static class IvrInfoExtractorEndpoints
    {
        // Transcript Extraction

        public static string GetTranscriptExtractionEndpoint() =>
            $"{Config.BASE_URN}/TranscriptExtraction";
    }
}
