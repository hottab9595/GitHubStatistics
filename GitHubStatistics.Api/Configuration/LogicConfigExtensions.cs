using GitHubStatistics.Common.Core.Configuration;
using GitHubStatistics.Common.Interfaces;
using GitHubStatistics.Services.ConfigurationOptions;
using GitHubStatistics.Services.Core;
using GitHubStatistics.Services.Interfaces;

namespace GitHubStatistics.Api.Configuration
{
    public static class LogicConfigExtensions
    {
        public static IServiceCollection AddServerLogic(
            this IServiceCollection services,
            IConfigurationSection domainSection,
            IConfigurationSection gitHubSection)
        {
            services.Configure<DomainOptions>(domainSection);
            services.Configure<AuthOptions>(gitHubSection);

            services.AddHttpClient();

            services
                .AddSingleton<IDomain, DomainOptions>()
                .AddSingleton<IAuthOptions, AuthOptions>()
                .AddTransient<IRequestClient, RequestClient>()
                .AddTransient<IGitHubRepo, GitHubRepoService>()
                .AddTransient<IGitHubRepoStatistics, GitHubRepoStatisticsService>();

            return services;
        }
    }
}
