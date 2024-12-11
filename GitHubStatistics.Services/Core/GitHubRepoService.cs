using GitHubStatistics.Common;
using GitHubStatistics.Common.Interfaces;
using GitHubStatistics.Services.ConfigurationOptions;
using GitHubStatistics.Services.Interfaces;
using GitHubStatistics.Services.Models.Request;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Text;
using GitHubStatistics.Services.Models.Response;

namespace GitHubStatistics.Services.Core
{
    public class GitHubRepoService : IGitHubRepo
    {
        private readonly IRequestClient _requestClient;
        private readonly DomainOptions _domenOptions;

        public GitHubRepoService(IRequestClient requestClient,
            IOptions<DomainOptions> domenOptions)
        {
            _requestClient = requestClient;
            _domenOptions = domenOptions.Value;
        }

        public async Task<IList<string>> GetGitHubRepoByTypeAsync(string owner, string repo, string branchName, string fileTypes)
        {
            GetLimitResponse limitResponse = await _requestClient.SendRequestAsync<GetLimitResponse>(new GetLimitRequest(_domenOptions));

            if (limitResponse.Data.Rate.Remaining < Constants.ParallelTasks.MIN_REQUEST_LIMIT)
            {
                throw new HttpRequestException(Constants.ExceptionMessages.RATE_LIMIT);
            }

            GetCommitResponse commitResponse = await _requestClient.SendRequestAsync<GetCommitResponse>(new GetCommitRequest(_domenOptions
                                                                                                                                , owner
                                                                                                                                , repo
                                                                                                                                , $"/{branchName}"));

            if(string.IsNullOrEmpty(commitResponse.Data.Sha))
            {
                throw new HttpRequestException(Constants.ExceptionMessages.BRANCH_NOT_FOUND);
            }

            GetTreeResponse treeResponse = await _requestClient.SendRequestAsync<GetTreeResponse>(new GetTreeRequest(_domenOptions
                                                                                                                        , owner
                                                                                                                        , repo
                                                                                                                        , commitResponse.Data.Sha));

            return await GetFilesInParallelInWithBatchesAsync(treeResponse.Data.Tree.Where(x => fileTypes.Split(',').Contains(x.Extension))
                                                                                    .Select(x => x.Url));
        }

        private async Task<IList<string>> GetFilesInParallelInWithBatchesAsync(IEnumerable<string> urls)
        {
            OrderablePartitioner<string> partitioner = Partitioner.Create(urls.ToList(), true);
            ConcurrentBag<string> results = [];

            List<Task> tasks = [];

            foreach (IEnumerator<string> partition in partitioner.GetPartitions(Environment.ProcessorCount))
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (partition)
                    {
                        while (partition.MoveNext())
                        {
                            results.Add(await DownloadFileAsync(partition.Current));
                        }
                    }
                }));
            }

            await Task.WhenAll(tasks);

            return results.ToList();
        }

        private async Task<string> DownloadFileAsync(string fileUrl)
        {
            GetFileResponse fileResponse = await _requestClient.SendRequestAsync<GetFileResponse>(new GetByNavigationLinkRequest(new Uri(fileUrl)));

            return Encoding.UTF8.GetString(Convert.FromBase64String(fileResponse.Data.Content));
        }
    }
}
