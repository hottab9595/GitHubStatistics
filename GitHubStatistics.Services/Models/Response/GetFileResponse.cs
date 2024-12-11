using GitHubStatistics.Common.Core.HttpMessaging;
using GitHubStatistics.Data.Models.GetFile;

namespace GitHubStatistics.Services.Models.Response
{
    public class GetFileResponse : Response<Root>
    {
        public GetFileResponse(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }
    }
}
