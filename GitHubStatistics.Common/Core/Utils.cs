using System.Net.Http.Headers;

namespace GitHubStatistics.Common.Core
{
    public static class Utils
    {
        /// <summary>
        /// ConfigureBearerAuthorization
        /// </summary>
        /// <param name="httpClient">instance of HttpClient</param>
        /// <param name="token">bearer tocken</param>
        /// <returns>instance of HttpClient</returns>
        public static HttpClient ConfigureBearerAuthorization(this HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.Requests.BEARER_HEADER, token);
            return httpClient;
        }

        /// <summary>
        /// Configure User Agent header
        /// </summary>
        /// <param name="httpClient">instance of HttpClient</param>
        /// <param name="token">app name</param>
        /// <returns>instance of HttpClient</returns>
        public static HttpClient ConfigureUserAgent(this HttpClient httpClient, string value)
        {
            httpClient.DefaultRequestHeaders.Add(Constants.Requests.USER_AGENT_HEADER, value);
            return httpClient;
        }
    }
}
