# GitHubStatistics Api
This project allows you to get statistics from the GitHub repository using the REST Api. You can use it to get statistics on files in the repository. For example, how often a symbol is found in repository files of a certain type.
## Project structure
- **Controllers**
  Handle requests and invoke necessary services.
- **Services**
  Contains business logic for this project. i.e. letter counting, sending requests etc.
- **Data**
  Response models from GitHub.
  
## Usage
1. Configure user secrets for the project Api.
```json
{
  "GitHubOptions": {
    "Token": "Your GitHub personal access token"
  }
}
```

2. Run the GitHubStatistics.Api project
3. Use GET api/github/repos/statistics endpoint to get the data. Required query parameters are
   - owner - owner of repository.
   - repo - repository name.
   - branchName - branch in this repository. The business logic based on the branch sha.
   - fileTypes - list of file extentions in the next format - js,ts
  
## Key features
- Getting data from the GitHub repository using a recursive tree query.
- Checking for the exhaustion of the request limit.
- Asynchronous data acquisition and processing based on your CPU.
- Getting data from the required repository branch, as well as custom processing of the file type list.

## Tests
The main methods of business logic are covered by tests using FluentAssertions, Moq, xUnit. Also in the screenshot below you can see the benchmark test data for calculating statistics in asynchronous and synchronous versions.
   ![Benchmark](https://github.com/user-attachments/assets/6d11789f-010e-4bf1-baaa-0d4cd806fb37)
