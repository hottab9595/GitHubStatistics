using GitHubStatistics.Common;
using GitHubStatistics.Common.Core;
using GitHubStatistics.Common.Core.Configuration;
using Microsoft.Extensions.Options;

namespace GitHubStatistics.Services.Core
{
    public class RequestClient : Common.Core.HttpMessaging.RequestClient
    {
        public RequestClient(IHttpClientFactory httpClientFactory, IOptions<AuthOptions> authOptions) : base(httpClientFactory)
        => base._httpClient.ConfigureBearerAuthorization(authOptions.Value.Token)
            .ConfigureUserAgent(Constants.Requests.APP_NAME_HEADER);
    }
}
