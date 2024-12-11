using GitHubStatistics.Common.Interfaces;

namespace GitHubStatistics.Services.ConfigurationOptions
{
    public class DomainOptions : IDomain
    {
        public string Domain { get; set; } = default!;
    }
}
