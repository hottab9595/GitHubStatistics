namespace GitHubStatistics.Services.Interfaces
{
    public interface IGitHubRepoStatistics
    {
        Task<Dictionary<char, int>> GetStatisticsAsync(string owner, string repo, string branchName, string fileTypes);
    }
}
