using GitHubStatistics.Common.Interfaces;
using System.Text;

namespace GitHubStatistics.Services.Models.Request
{
    public class Request : Common.Core.HttpMessaging.Request
    {
        private protected Request() : base() { }

        private protected Request(IDomain domain, string path) : base()
            => base.RequestUri = new(new StringBuilder(domain.Domain).Append(path).ToString());
    }
}
