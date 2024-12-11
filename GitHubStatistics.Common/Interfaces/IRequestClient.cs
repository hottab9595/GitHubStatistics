using GitHubStatistics.Common.Core.HttpMessaging;

namespace GitHubStatistics.Common.Interfaces
{
    public interface IRequestClient
    {
        Task<T> SendRequestAsync<T>(HttpRequestMessage request) where T : Response;
    }
}
