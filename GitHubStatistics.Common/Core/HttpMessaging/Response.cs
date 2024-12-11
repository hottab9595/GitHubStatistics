using System.Text.Json;

namespace GitHubStatistics.Common.Core.HttpMessaging
{
    public abstract class Response<T> : Response
    {
        public Response(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage) { }

        public T Data { get; private set; } = default!;

        protected override void DeserializeContent(string content)
        {
            try
            {
                T? t = JsonSerializer.Deserialize<T>(content);

                if (t == null)
                {
                    throw new ArgumentNullException(nameof(content));
                }

                Data = t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }

    public abstract class Response
    {
        public Response(HttpResponseMessage httpResponseMessage) => this.httpResponseMessage = httpResponseMessage;

        private readonly HttpResponseMessage httpResponseMessage;

        public async Task ParseContentAsync() => DeserializeContent(await httpResponseMessage.Content.ReadAsStringAsync());

        protected abstract void DeserializeContent(string content);
    }
}
