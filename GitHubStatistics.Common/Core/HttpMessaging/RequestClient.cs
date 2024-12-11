using GitHubStatistics.Common.Interfaces;

namespace GitHubStatistics.Common.Core.HttpMessaging
{
    public abstract class RequestClient : IRequestClient
    {
        public RequestClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory
                .CreateClient();
            _token = new CancellationTokenSource().Token;
        }

        protected readonly HttpClient _httpClient;
        private readonly CancellationToken _token;

        public async Task<T> SendRequestAsync<T>(HttpRequestMessage request) where T : Response
        {
            T response = (T?)Activator.CreateInstance(typeof(T), await _httpClient.SendAsync(request, _token)) ?? default!;
            await response.ParseContentAsync();

            return response;
        }
    }
}
