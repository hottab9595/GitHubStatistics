using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetCommit
{
    public class Committer : Common.Person
    {
        [JsonPropertyName("site_admin")]
        public bool TiteAdmin { get; set; }
    }
}
