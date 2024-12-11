using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.Common
{
    public abstract class Root
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; } = default!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;
    }
}
