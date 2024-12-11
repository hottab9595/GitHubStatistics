using System.Text.Json.Serialization;

namespace GitHubStatistics.Data.Models.Common
{
    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("email")]
        public string Email { get; set; } = default!;

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; } = default!;

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeID { get; set; } = default!;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; } = default!;

        [JsonPropertyName("gravatar_id")]
        public string GravatarID { get; set; } = default!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = default!;

        [JsonPropertyName("followers_url")]
        public string FollowersUrl { get; set; } = default!;

        [JsonPropertyName("following_url")]
        public string FollowingUrl { get; set; } = default!;

        [JsonPropertyName("gists_url")]
        public string GistsUrl { get; set; } = default!;

        [JsonPropertyName("starred_url")]
        public string StarredUrl { get; set; } = default!;

        [JsonPropertyName("subscriptions_url")]
        public string SubscriptionsUrl { get; set; } = default!;

        [JsonPropertyName("organizations_url")]
        public string OrganizationsUrl { get; set; } = default!;

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; set; } = default!;

        [JsonPropertyName("events_url")]
        public string EventsUrl { get; set; } = default!;

        [JsonPropertyName("received_events_url")]
        public string ReceivedEventsUrl { get; set; } = default!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("user_view_type")]
        public string UserViewType { get; set; } = default!;
    }
}
