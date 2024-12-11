using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.GetCommit
{
    public class Author : Common.Person
    {
        [JsonPropertyName("site_admin")]
        public bool SiteAdmin { get; set; }
    }
}
