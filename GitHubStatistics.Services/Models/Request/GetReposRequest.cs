using GitHubStatistics.Common;
using GitHubStatistics.Common.Interfaces;
using System.Text;

namespace GitHubStatistics.Services.Models.Request
{
    public class GetReposRequest : GetRequest
    {
        private protected GetReposRequest(IDomain domain, string owner, string repo, string path = "") : base(domain, new StringBuilder(Constants.Requests.URL_REPOS)
                                                                                                                                        .Append($"{owner}/{repo}")
                                                                                                                                        .Append(path)
                                                                                                                                        .ToString())
        {

        }

        public GetReposRequest(IDomain domain, string owner, string repo) : this(domain, owner, repo, default!) { }
    }
}
