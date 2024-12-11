using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetCommit
{
    public class Verification
    {
        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; } = default!;

        [JsonPropertyName("signature")]
        public string Signature { get; set; } = default!;

        [JsonPropertyName("payload")]
        public string Payload { get; set; } = default!;

        [JsonPropertyName("verified_at")]
        public DateTime VerifiedAt { get; set; }
    }
}
