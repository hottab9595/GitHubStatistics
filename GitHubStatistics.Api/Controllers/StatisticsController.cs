using Microsoft.AspNetCore.Mvc;
using GitHubStatistics.Services.Interfaces;

namespace GitHubStatistics.Api.Controllers
{
    [ApiController]
    [Route("api/github/repos")]
    public class StatisticsController : Controller
    {
        private readonly IGitHubRepoStatistics _gitHubRepoStatistics;
        public StatisticsController(IGitHubRepoStatistics gitHubRepoStatistics)
        {
            this._gitHubRepoStatistics = gitHubRepoStatistics;
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> Login([FromQuery] string owner, [FromQuery] string repo, [FromQuery] string branchName, [FromQuery] string fileTypes) 
            => Ok(await _gitHubRepoStatistics.GetStatisticsAsync(owner, repo, branchName, fileTypes));
    }
}
