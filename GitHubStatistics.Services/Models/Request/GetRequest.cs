using GitHubStatistics.Common.Interfaces;

namespace GitHubStatistics.Services.Models.Request
{
    public abstract class GetRequest : Request
    {
        protected GetRequest() : base() => base.Method = HttpMethod.Get;

        public GetRequest(IDomain domain, string path) : base(domain, path) => base.Method = HttpMethod.Get;
    }
}
