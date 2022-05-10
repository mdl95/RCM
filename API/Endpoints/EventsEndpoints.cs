using RCM.API.Support;

namespace RCM.API.Endpoints
{
    public static class EventsEndpoints
    {
        // Events

        public static string GetEventsEndpoint() =>
            $"{Config.BASE_URN}/events/detect";
    }
}
