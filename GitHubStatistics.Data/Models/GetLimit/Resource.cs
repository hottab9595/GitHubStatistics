using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetLimit
{
    public class Resource
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("used")]
        public int Used { get; set; }

        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }

        [JsonPropertyName("reset")]
        public int Reset { get; set; }
    }
}