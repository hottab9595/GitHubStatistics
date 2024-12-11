using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetLimit
{
    public class Root
    {
        [JsonPropertyName("resources")]
        public Resources Resources { get; set; } = default!;

        [JsonPropertyName("rate")]
        public Resource Rate { get; set; } = default!;
    }
}
