using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetCommit
{
    public class Root : Common.Root
    {
        [JsonPropertyName("node_id")]
        public string NodeID { get; set; } = default!;

        [JsonPropertyName("commit")]
        public Commit Commit { get; set; } = default!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = default!;

        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; } = default!;

        [JsonPropertyName("author")]
        public Author Author { get; set; } = default!;

        [JsonPropertyName("committer")]
        public Committer Committer { get; set; } = default!;

        [JsonPropertyName("parents")]
        public List<Parent> Parents { get; set; } = default!;

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; } = default!;

        [JsonPropertyName("files")]
        public List<File> Files { get; set; } = default!;
    }
}
