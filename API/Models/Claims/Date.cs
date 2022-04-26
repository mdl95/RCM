using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class Date
    {
        public enum Days
        {
            Sunday = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6
        }


        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("dayOfWeek")]
        public Days DayOfWeek { get; set; }

        // Specified by schema as 'readonly' but can use set for negative testing
        [JsonProperty("dayOfYear")]
        public int DayOfYear { get; set; }

        // Specified by schema as 'readonly' but can use set for negative testing
        [JsonProperty("dayNumber")]
        public int DayNumber { get; set; }
    }
}