using GitHubStatistics.Common;
using GitHubStatistics.Common.Interfaces;
using System.Text;

namespace GitHubStatistics.Services.Models.Request
{
    public class GetLimitRequest : GetRequest
    {
        private protected GetLimitRequest(IDomain domain, string path = "") : base(domain, new StringBuilder(Constants.Requests.URL_RATE_LIMIT)
                                                                                                            .Append(path)
                                                                                                            .ToString())
        {
            
        }

        public GetLimitRequest(IDomain domain) : this(domain, default!) { }
    }
}
