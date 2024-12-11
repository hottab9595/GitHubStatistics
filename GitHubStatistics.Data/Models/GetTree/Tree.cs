using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetTree
{
    public class Tree
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; } = default!;

        [JsonPropertyName("path")]
        public string FilePath { get; set; } = default!;

        [JsonPropertyName("mode")]
        public string Mode { get; set; } = default!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;

        public string Extension => Path.GetExtension(FilePath).TrimStart('.');
    }
}
