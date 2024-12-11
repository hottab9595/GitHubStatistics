namespace GitHubStatistics.Services.Interfaces
{
    public interface IGitHubRepo
    {
        Task<IList<string>> GetGitHubRepoByTypeAsync(string owner, string repo, string branchName, string fileTypes);
    }
}
