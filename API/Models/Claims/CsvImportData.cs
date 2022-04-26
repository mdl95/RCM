using Newtonsoft.Json;
using System.Collections.Generic;

namespace RCM.API.Models.Claims
{
    public class CsvImportData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rejectedLineCount")]
        public int RejectedLineCount { get; set; }

        [JsonProperty("rejectedEntirely")]
        public bool RejectedEntirely { get; set; }

        [JsonProperty("fileHadHeader")]
        public bool FileHadHeader { get; set; }

        [JsonProperty("fatalHeaderProblem")]
        public bool FatalHeaderProblem { get; set; }

        [JsonProperty("claimCount")]
        public int ClaimCount { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("csvClaims")]
        public List<CsvClaimData> CsvClaims { get; set; }

        [JsonProperty("csvImportProblems")]
        public List<CsvImportProblem> CsvImportProblems { get; set; }
    }
}
