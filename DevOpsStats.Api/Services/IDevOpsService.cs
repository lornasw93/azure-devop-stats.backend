using System;
using System.Threading.Tasks;
using DevOpsStats.Api.Models.Build;
using DevOpsStats.Api.Models.Release;

namespace DevOpsStats.Api.Services
{
    public interface IDevOpsService
    {
        Task<object> GetProjects();
        Task<object> GetWiki(string project);

        Task<object> GetReleases(string project);
        Task<object> GetIterations(string project);
        Task<object> GetGitRepos(string project);
        Task<object> GetPullRequestsByProject(string project);
        Task<object> GetPullRequestsByRepo(string project, Guid repoId);


        Task<Build> GetBuild(string project, int buildId);
        Task<Release> GetRelease(string project, int releaseId);
        Task<object> GetGitRepo(string project, Guid repoId);
    }
}
