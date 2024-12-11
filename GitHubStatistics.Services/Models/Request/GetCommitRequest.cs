using GitHubStatistics.Common;
using GitHubStatistics.Common.Interfaces;
using System.Text;

namespace GitHubStatistics.Services.Models.Request
{
    public class GetCommitRequest : GetReposRequest
    {
        private protected GetCommitRequest(IDomain domain, string owner, string repo, string branchName, string path = "") 
            : base(domain
                  , owner
                  , repo
                  , new StringBuilder(Constants.Requests.URL_COMMITS)
                  .Append(branchName)
                  .Append(path)
                  .ToString())
        {
            
        }

        public GetCommitRequest(IDomain domain, string owner, string repo, string branchName) : this(domain, owner, repo, branchName, default!) { }
    }
}
