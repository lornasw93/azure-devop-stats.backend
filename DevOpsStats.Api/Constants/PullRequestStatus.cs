namespace DevOpsStats.Api.Constants
{
    public static class PullRequestStatus
    {
        public static string Abandoned = "abandoned";
        public static string Active = "active";
        public static string All = "all";
        public static string Completed = "completed";
    }

    public static class SprintTimeFrame
    {
        public static string Current = "current";
        public static string Future = "future";
        public static string Past = "past";
    }

    public static class BuildStatus
    {
        public static string All = "all"; //All
        public static string Cancelling = "cancelling";//The build is cancelling
        public static string Completed = "completed";//The build has completed
        public static string InProgress = "inProgress";//The build is currently in progress
        public static string None = "none";//No status
        public static string NotStarted = "notStarted";//The build has not yet started
        public static string Postponed = "postponed";//The build is inactive in the queue
    }
     
    public static class BuildResult
    { 
        public static string Cancelled = "canceled";//The build was canceled before starting
        public static string Failed = "failed";//The build completed unsuccessfully
        public static string None = "none";//No result
        public static string PartiallySucceeded = "partiallySucceeded";//
        public static string Succeeded = "succeeded";//The build completed successfully
    }

    public static class ReleaseStatus
    {
        public static string Abandoned = "abandoned";//Release status is in abandoned
        public static string Active = "active";//Release status is in active
        public static string Draft = "draft";//Release is in draft state
        public static string Undefined = "undefined";//Release status not set
    }
     
    public static class ReleaseTaskStatus
    {
        public static string Cancelled = "canceled";
        public static string Failed = "failed";
        public static string Failure = "failure";
        public static string InProgress = "inProgress";
        public static string PartiallySucceeded = "partiallySucceeded";
        public static string Pending = "pending";
        public static string Skipped = "skipped";
        public static string Succeeded = "succeeded";
        public static string Success = "success";
        public static string Unknown = "unknown";
    } 
}
