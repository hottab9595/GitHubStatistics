using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetCommit
{
    public class Commit
    {
        [JsonPropertyName("author")]
        public Author Author { get; set; } = default!;

        [JsonPropertyName("committer")]
        public Committer Committer { get; set; } = default!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = default!;

        [JsonPropertyName("tree")]
        public Tree Tree { get; set; } = default!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        [JsonPropertyName("verification")]
        public Verification Verification { get; set; } = default!;
    }
}
