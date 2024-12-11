using GitHubStatistics.Services.Interfaces;
using System.Collections.Concurrent;

namespace GitHubStatistics.Services.Core
{
    public class GitHubRepoStatisticsService : IGitHubRepoStatistics
    {
        private readonly IGitHubRepo _gitHubRepo;

        public GitHubRepoStatisticsService(IGitHubRepo gitHubRepo)
        {
            this._gitHubRepo = gitHubRepo;
        }

        public async Task<Dictionary<char, int>> GetStatisticsAsync(string owner, string repo, string branchName, string fileTypes)
        {
            IList<string> files = await _gitHubRepo.GetGitHubRepoByTypeAsync(owner, repo, branchName, fileTypes);

            ConcurrentDictionary<char, int> symbolCounts = [];
            SemaphoreSlim semaphore = new(10);
            List<Task> tasks = [];

            foreach (string file in files)
            {
                tasks.Add(Task.Run(async () =>
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        Dictionary<char, int> counts = CountSymbolsInString(file);

                        foreach (var kvp in counts)
                        {
                            symbolCounts.AddOrUpdate(kvp.Key, kvp.Value, (key, oldValue) => oldValue + kvp.Value);
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);

            return symbolCounts.OrderByDescending(x => x.Value).ToDictionary();
        }

        private Dictionary<char, int> CountSymbolsInString(string str)
        {
            Dictionary<char, int> counts = [];

            foreach (char c in str)
            {
                if (counts.ContainsKey(c))
                {
                    counts[c]++;
                }
                else if(char.IsLetter(c))
                {
                    counts[c] = 1;
                }
            }

            return counts;
        }
    }
}
