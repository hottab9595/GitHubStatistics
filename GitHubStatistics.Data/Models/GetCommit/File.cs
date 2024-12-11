using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetCommit
{
    public class File
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; } = default!;

        [JsonPropertyName("filename")]
        public string FileName { get; set; } = default!;

        [JsonPropertyName("status")]
        public string Status { get; set; } = default!;

        [JsonPropertyName("additions")]
        public int Additions { get; set; }

        [JsonPropertyName("deletions")]
        public int Deletions { get; set; }

        [JsonPropertyName("changes")]
        public int Changes { get; set; }

        [JsonPropertyName("blob_url")]
        public string BlobUrl { get; set; } = default!;

        [JsonPropertyName("raw_url")]
        public string RawUrl { get; set; } = default!;

        [JsonPropertyName("contents_url")]
        public string ContentsUrl { get; set; } = default!;

        [JsonPropertyName("patch")]
        public string Patch { get; set; } = default!;
    }
}
