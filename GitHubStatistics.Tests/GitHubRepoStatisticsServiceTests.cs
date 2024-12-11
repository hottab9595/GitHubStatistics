using FluentAssertions;
using GitHubStatistics.Services.Core;
using GitHubStatistics.Services.Interfaces;
using Moq;
using Xunit;

namespace GitHubStatistics.Tests
{
    public class GitHubRepoStatisticsServiceTests
    {
        private readonly Mock<IGitHubRepo> _mockGitHubRepo;
        private readonly GitHubRepoStatisticsService _service;

        public GitHubRepoStatisticsServiceTests()
        {
            _mockGitHubRepo = new Mock<IGitHubRepo>();
            _service = new GitHubRepoStatisticsService(_mockGitHubRepo.Object);
        }

        [Fact]
        public async Task GetStatisticsAsync_ShouldReturnCorrectCounts_WhenFilesAreProvided()
        {
            // Arrange
            var files = new List<string>
            {
                "abc",
                "aabbcc",
                "123!!"
            };

            _mockGitHubRepo
                .Setup(repo => repo.GetGitHubRepoByTypeAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(files);

            // Act
            var result = await _service.GetStatisticsAsync("owner", "repo", "branch", "fileTypes");

            // Assert
            result.Should().Contain(new KeyValuePair<char, int>('a', 3));
            result.Should().Contain(new KeyValuePair<char, int>('b', 3));
            result.Should().Contain(new KeyValuePair<char, int>('c', 3));
        }

        [Fact]
        public async Task GetStatisticsAsync_ShouldReturnEmptyDictionary_WhenNoFilesAreProvided()
        {
            // Arrange
            _mockGitHubRepo
                .Setup(repo => repo.GetGitHubRepoByTypeAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new List<string>());

            // Act
            var result = await _service.GetStatisticsAsync("owner", "repo", "branch", "fileTypes");

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetStatisticsAsync_ShouldHandleConcurrencyCorrectly()
        {
            // Arrange
            var files = new List<string>
            {
                new string('a', 10000),
                new string('b', 10000),
                new string('c', 10000)
            };

            _mockGitHubRepo
                .Setup(repo => repo.GetGitHubRepoByTypeAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(files);

            // Act
            var result = await _service.GetStatisticsAsync("owner", "repo", "branch", "fileTypes");

            // Assert
            result['a'].Should().Be(10000);
            result['b'].Should().Be(10000);
            result['c'].Should().Be(10000);
        }

        [Fact]
        public void CountSymbolsInString_ShouldCountLetters()
        {
            // Arrange
            var privateMethod = typeof(GitHubRepoStatisticsService)
                .GetMethod("CountSymbolsInString", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var testString = "a1!b2@";

            // Act
            var result = privateMethod?.Invoke(_service, [testString]) as Dictionary<char, int>;

            // Assert
            result.Should().Contain(new KeyValuePair<char, int>('a', 1));
            result.Should().Contain(new KeyValuePair<char, int>('b', 1));
            result.Should().NotContainKey('1');
            result.Should().NotContainKey('!');
            result.Should().NotContainKey('2');
            result.Should().NotContainKey('@');
        }
    }
}
