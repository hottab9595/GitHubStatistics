using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetLimit
{
    public class Resources
    {
        [JsonPropertyName("core")]
        public Resource Core { get; set; } = default!;

        [JsonPropertyName("search")]
        public Resource Search { get; set; } = default!;

        [JsonPropertyName("graphql")]
        public Resource GraphQL { get; set; } = default!;

        [JsonPropertyName("integration_manifest")]
        public Resource IntegrationManifest { get; set; } = default!;

        [JsonPropertyName("source_import")]
        public Resource SourceImport { get; set; } = default!;

        [JsonPropertyName("code_scanning_upload")]
        public Resource CodeScanningUpload { get; set; } = default!;

        [JsonPropertyName("code_scanning_autofix")]
        public Resource CodeScanningAutofix { get; set; } = default!;

        [JsonPropertyName("actions_runner_registration")]
        public Resource ActionsRunnerRegistration { get; set; } = default!;

        [JsonPropertyName("scim")]
        public Resource Scim { get; set; } = default!;

        [JsonPropertyName("dependency_snapshots")]
        public Resource DependencySnapshots { get; set; } = default!;

        [JsonPropertyName("audit_log")]
        public Resource AuditLog { get; set; } = default!;

        [JsonPropertyName("audit_log_streaming")]
        public Resource AuditLogStreaming { get; set; } = default!;

        [JsonPropertyName("code_search")]
        public Resource CodeSearch { get; set; } = default!;
    }
}
