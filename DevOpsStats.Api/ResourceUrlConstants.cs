namespace DevOpsStats.Api
{
    public static class ResourceUrlConstants
    {
        private static readonly string Api = "_apis";

        public static string BuildUrl = $"{Api}/build/builds";
        public static string ReleaseUrl = $"{Api}/release/releases";
        public static string WikiUrl = $"{Api}/wiki/wikis";
        public static string SprintUrl = $"{Api}/work/teamsettings/iterations";
        public static string RepoUrl = $"{Api}/git/repositories";
        public static string PullRequestUrl = $"{Api}/git/pullrequests";
        public static string ProjectUrl = $"{Api}/projects"; 
        public static string BacklogUrl = $"/{Api}/work/backlogs";
        public static string TestPlanUrl = $"{Api}/test/runs";
    }
}
