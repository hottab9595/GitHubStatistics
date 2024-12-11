namespace GitHubStatistics.Services.Models.Request
{
    public class GetByNavigationLinkRequest : GetRequest
    {
        public GetByNavigationLinkRequest(Uri navigationLink) : base() => base.RequestUri = navigationLink;
    }
}
