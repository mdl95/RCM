using Newtonsoft.Json;

namespace RCM.API.Models.Claims
{
    public class CsvImportProblem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("problemType")]
        public string ProblemType { get; set; }

        [JsonProperty("line")]
        public int Line { get; set; }

        [JsonProperty("column")]
        public string Column { get; set; }

        [JsonProperty("instance")]
        public string Instance { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}