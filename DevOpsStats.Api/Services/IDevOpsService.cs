using System;
using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.DevOps.Build;
using DevOpsStats.Api.Models.DevOps.Iteration;
using DevOpsStats.Api.Models.DevOps.Project;
using DevOpsStats.Api.Models.DevOps.Release;
using DevOpsStats.Api.Models.DevOps.Wiki;

namespace DevOpsStats.Api.Services
{
    public interface IDevOpsService
    {
        Task<Build> GetBuild(string project, int buildId);
        Task<ValueList<Build>> GetBuilds(string project);
        Task<ProjectList> GetProjects();
        Task<object> GetPullRequestsByProject(string project);
        Task<object> GetPullRequestsByRepo(string project, Guid repoId);
        Task<ReleaseList> GetReleases(string project);
        Task<Release> GetRelease(string project, int releaseId);
        Task<object> GetGitRepos(string project);
        Task<object> GetGitRepo(string project, Guid repoId);
        Task<IterationList> GetIterations(string project);
        Task<WikiList> GetWiki(string project);
    }
}
