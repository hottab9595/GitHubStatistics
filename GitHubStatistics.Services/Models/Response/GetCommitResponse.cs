using GitHubStatistics.Common.Core.HttpMessaging;
using GitHubStatistics.Data.Models.GetCommit;

namespace GitHubStatistics.Services.Models.Response
{
    public class GetCommitResponse : Response<Root>
    {
        public GetCommitResponse(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
    }
}
