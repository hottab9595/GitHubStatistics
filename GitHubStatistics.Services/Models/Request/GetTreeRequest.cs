using GitHubStatistics.Common;
using GitHubStatistics.Common.Interfaces;
using System.Text;

namespace GitHubStatistics.Services.Models.Request
{
    public class GetTreeRequest : GetReposRequest
    {
        private protected GetTreeRequest(IDomain domain, string owner, string repo, string sha, string path = "")
            : base(domain
                  , owner
                  , repo
                  , new StringBuilder(Constants.Requests.URL_TREES)
                  .Append(sha)
                  .Append(path)
                  .ToString())
        {
            base.AddQueryParameters(Constants.Requests.QueryFilters.URL_REQURSIVE_FILTER, Constants.Requests.QueryFilters.URL_REQURSIVE_FILTER_VALUE.ToString());
        }

        public GetTreeRequest(IDomain domain, string owner, string repo, string sha) : this(domain, owner, repo, sha, default!) { }
    }
}
