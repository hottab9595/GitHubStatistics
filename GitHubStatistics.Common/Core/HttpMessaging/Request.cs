using System.Collections.Specialized;
using System.Web;

namespace GitHubStatistics.Common.Core.HttpMessaging
{
    public abstract class Request : HttpRequestMessage
    {
        public Request() { }

        private protected Request(string path) : base() => RequestUri = new(path);

        protected void AddQueryParameters(string filter, string value)
        {
            if (string.IsNullOrEmpty(filter) || string.IsNullOrEmpty(value) || RequestUri == null)
            {
                return;
            }

            UriBuilder uriBuilder = new UriBuilder(RequestUri!);
            NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query.Remove(filter);
            query.Add(filter, value);

            uriBuilder.Query = query.ToString();
            RequestUri = uriBuilder.Uri;
        }
    }
}
