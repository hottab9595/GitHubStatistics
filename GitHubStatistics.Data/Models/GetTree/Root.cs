using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetTree
{
    public class Root : Common.Root
    {
        [JsonPropertyName("tree")]
        public IList<Tree> Tree { get; set; } = default!;

        [JsonPropertyName("truncated")]
        public bool Truncated { get; set; }
    }
}
