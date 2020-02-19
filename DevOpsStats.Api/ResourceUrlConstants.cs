namespace DevOpsStats.Api
{
    public static class ResourceUrlConstants
    {
        private static string Api = "_apis";

        public static string BuildUrl = $"{Api}/build/builds";
        public static string ReleaseUrl = $"{Api}/release/releases";
        public static string WikiUrl = $"{Api}/wiki/wikis";
        public static string IterationsUrl = $"{Api}/work/teamsettings/iterations";
        public static string RepoUrl = $"{Api}/git/repositories";
        public static string PullRequestUrl = $"{Api}/git/pullrequests";
        public static string ProjectUrl = $"{Api}/projects";
    }
}
