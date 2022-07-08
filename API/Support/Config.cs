namespace RCM.API.Support
{
    public static class Config
    {
        public static readonly string BASE_URN = "/api/v1";

        public static readonly string CALLS_BASE_URL_DEV = "https://calls.phoenix.newdev.virtualoutbound.com";
        public static readonly string CLAIMS_BASE_URL_DEV = "https://claims.phoenix.newdev.virtualoutbound.com";
        public static readonly string EVENTS_BASE_URL_DEV = "https://calltranscriptevent.phoenix.newdev.virtualoutbound.com";
        public static readonly string IVR_AGENT_BOT_URL_DEV = "https://ivragentbot.phoenix.newdev.virtualoutbound.com";
        public static readonly string IVR_INFO_EXTRACTOR_URL_DEV = "https://ivrextractor.phoenix.newdev.virtualoutbound.com";

        public static readonly string GRANT_TYPE = "authorization_code";
        public static readonly string TOKEN_URL_DEV = "https://outlift-newdev.auth.us-west-2.amazoncognito.com/oauth2/token";

        public static readonly string CLAIMS_CLIENT_ID_DEV = "414cjqjqivk6st5f2ec9bmj3tl";
        public static readonly string CLAIMS_AUTHORIZATION_URL_DEV = "https://outlift-newdev.auth.us-west-2.amazoncognito.com/oauth2/authorize";
    }
}
