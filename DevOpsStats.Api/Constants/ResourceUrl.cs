namespace DevOpsStats.Api.Constants
{
    public static class ResourceUrl
    {
        private static readonly string Api = "_apis";

        public static string RepoUrl = $"{Api}/git/repositories";
        
        
        
        public static string PullRequestUrl = $"{Api}/git/pullrequests";
        
        
        
        public static string ProjectUrl = $"{Api}/projects";
    }
}
