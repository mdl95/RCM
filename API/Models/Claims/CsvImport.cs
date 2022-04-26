using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.Claims
{
    public class CsvImport
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("data")]
        public List<CsvImportData> Data { get; set; }


        [JsonProperty("formFile")]
        public string FormFile { get; set; }
    }
}