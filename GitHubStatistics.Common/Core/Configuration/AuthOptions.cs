using GitHubStatistics.Common.Interfaces;

namespace GitHubStatistics.Common.Core.Configuration
{
    public class AuthOptions : IAuthOptions
    {
        public string Token { get; set; } = default!;
    }
}
