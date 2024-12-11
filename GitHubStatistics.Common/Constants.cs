namespace GitHubStatistics.Common
{
    public static class Constants
    {
        public static class ExceptionMessages
        {
            public const string RATE_LIMIT = "The rate limit has been reached";

            public const string BRANCH_NOT_FOUND = "The branch was not found";
        }

        public static class ParallelTasks
        {
            public const int MIN_REQUEST_LIMIT = 1;
            public const int BATCH_SIZE = 20;
        }

        public static class Requests
        {
            public const string URL_COMMITS = "/commits";

            public const string URL_RATE_LIMIT = "/rate_limit";

            public const string URL_REPOS = "/repos/";

            public const string URL_TREES = "/git/trees/";

            public const string BEARER_HEADER = "Bearer";

            public const string USER_AGENT_HEADER = "User-Agent";

            public const string APP_NAME_HEADER = "GitHub Statistics";

            public static class QueryFilters
            {
                public const string URL_REQURSIVE_FILTER = "recursive";

                public const int URL_REQURSIVE_FILTER_VALUE = 1;
            }
        }
    }
}
