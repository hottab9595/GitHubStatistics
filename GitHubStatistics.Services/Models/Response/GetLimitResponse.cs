using GitHubStatistics.Common.Core.HttpMessaging;
using GitHubStatistics.Data.Models.GetLimit;

namespace GitHubStatistics.Services.Models.Response
{
    public class GetLimitResponse : Response<Root>
    {
        public GetLimitResponse(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
    }
}
