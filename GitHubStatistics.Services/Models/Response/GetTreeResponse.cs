using GitHubStatistics.Common.Core.HttpMessaging;
using GitHubStatistics.Data.Models.GetTree;

namespace GitHubStatistics.Services.Models.Response
{
    public class GetTreeResponse : Response<Root>
    {
        public GetTreeResponse(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
    }
}
