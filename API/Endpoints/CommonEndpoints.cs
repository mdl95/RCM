using RCM.API.Support;

namespace RCM.API.Endpoints
{
    public class CommonEndpoints
    {
        // Health

        public static string GetHealthEndpoint() =>
            $"{Config.BASE_URN}/health";
    }
}
