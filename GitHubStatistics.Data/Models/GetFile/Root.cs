using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetFile
{
    public class Root : Common.Root
    {
        [JsonPropertyName("node_id")]
        public string NodeID { get; set; } = default!;

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; } = default!;

        [JsonPropertyName("encoding")]
        public string Encoding { get; set; } = default!;
    }
}
