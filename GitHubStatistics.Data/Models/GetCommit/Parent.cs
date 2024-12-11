using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetCommit
{
    public class Parent : Common.Root
    {
        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = default!;
    }
}
