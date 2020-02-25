using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Pipelines.Build;
using DevOpsStats.Api.Models.Pipelines.Release;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Models.Repos;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        protected override string ResourceName => $"{Api}/projects";

        private const int Second = 1;
        private const int Minute = 60 * Second;
        private const int Hour = 60 * Minute;
        private const int Day = 24 * Hour;
        private const int Month = 30 * Day;

        private readonly IBaseQuery _query;

        public ProjectsController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get project
        /// </summary>
        [HttpGet("/api/[controller]/{project}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Project> Get(string project)
        {
            var url = $"{ResourceName}/{project}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get project count
        /// </summary>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            var url = $"{ResourceName}/{project}";

            return Ok(_query.GetCount(url));
        }



        /// <summary>
        /// Get all projects in the organization that the authenticated user has access to
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Project>> Get()
        {
            var projects = GetListOfProjects();

            string[] faves = { "fpmcore", "mysurgeryproducts", "erscrm" };

            foreach (var project in projects)
            {
                project.RepoCount = GetRepoCountForProject(project.Id);
                project.BuildCount = GetBuildCountForProject(project.Id);
                project.ReleaseCount = GetReleaseCountForProject(project.Id);
                project.IsFavourite = faves.Contains(project.Name.ToLower());

                project.AllPullRequestCount = GetPullRequestsByStatus(project.Id, PullRequestStatus.All);
                if (project.AllPullRequestCount > 0)
                {
                    project.CompletedPullRequestCount = GetPullRequestsByStatus(project.Id, PullRequestStatus.Completed);
                    project.ActivePullRequestCount = GetPullRequestsByStatus(project.Id, PullRequestStatus.Active);
                    project.AbandonedPullRequestCount = GetPullRequestsByStatus(project.Id, PullRequestStatus.Abandoned);
                }

                var buildsList = GetListOfBuilds(project.Id);
                if (buildsList.Any())
                {
                    project.BuildInProgressCount = buildsList.Count(l => l.Result.Equals(BuildStatus.InProgress));
                    project.BuildFailedCount = buildsList.Count(l => l.Result.Equals(BuildResult.Failed));
                    project.BuildCancelledCount = buildsList.Count(l => l.Result.Equals(BuildResult.Cancelled));
                    project.BuildSucceededCount = buildsList.Count(l => l.Result.Equals(BuildResult.Succeeded));
                }

                var releasesList = GetListOfReleases(project.Id);
                if (releasesList.Any())
                {
                    project.ReleaseInProgressCount = releasesList.Count(l => l.Status.Equals(ReleaseTaskStatus.InProgress));
                    project.ReleaseFailedCount = releasesList.Count(l => l.Status.Equals(ReleaseTaskStatus.Failed));
                    project.ReleaseCancelledCount = releasesList.Count(l => l.Status.Equals(ReleaseTaskStatus.Cancelled));
                    project.ReleaseSucceededCount = releasesList.Count(l => l.Status.Equals(ReleaseTaskStatus.Succeeded));
                }
            }

            var t = projects.OrderByDescending(x => x.IsFavourite).ThenByDescending(y => y.Name);

            return Ok(t);
        }






        private int GetRepoCountForProject(string project)
        {
            var count = _query.GetCount($"{project}/{Api}/git/repositories");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        }
        private int GetBuildCountForProject(string project)
        {
            var count = _query.GetCount($"{project}/{Api}/build/builds");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        }
        private int GetReleaseCountForProject(string project)
        {
            var count = _query.GetCount($"{project}/{Api}/release/releases");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        }
        private int GetPullRequestsByStatus(string project, string status)
        {
            var repos = GetListOfRepos(project);

            return repos
                .Select(repo => _query
                    .GetCount($"{project}/_apis/git/repositories/{repo.Id}/pullRequests?searchCriteria.status={status}"))
                .Select(itemList => itemList.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(itemList.Result.Count.ToString()) : 0)
                .Sum();
        }

        private IEnumerable<Project> GetListOfProjects()
        {
            var list = new List<Project>();

            var itemList = _query.GetList(ResourceName);

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Project>>(itemList.Result.List.ToString());

            return list;
        }
        private IEnumerable<Repo> GetListOfRepos(string project)
        {
            var list = new List<Repo>();

            var itemList = _query.GetList($"{project}/{Api}/git/repositories");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Repo>>(itemList.Result.List.ToString());

            return list;
        }
        private IEnumerable<Build> GetListOfBuilds(string project)
        {
            var list = new List<Build>();

            var itemList = _query.GetList($"{project}/{Api}/build/builds");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Build>>(itemList.Result.List.ToString());

            return list;
        }
        private IEnumerable<Release> GetListOfReleases(string project)
        {
            var list = new List<Release>();

            var itemList = _query.GetList($"{project}/_apis/release/releases");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Release>>(itemList.Result.List.ToString());

            return list;
        }


        private string GetDiff(DateTime date)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            var delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * Minute)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * Minute)
                return "a minute ago";

            if (delta < 45 * Minute)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * Minute)
                return "an hour ago";

            if (delta < 24 * Hour)
                return ts.Hours + " hours ago";

            if (delta < 48 * Hour)
                return "yesterday";

            if (delta < 30 * Day)
                return ts.Days + " days ago";

            if (delta < 12 * Month)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }

        /// <summary>
        /// Get count of repos per project
        /// </summary>
        [HttpGet("repoCount")]
        public IEnumerable<Result> GetRepoCountPerProject()
        {
            var projects = GetListOfProjects();

            var result = (from project in projects
                          let repos = GetListOfRepos(project.Name)
                          select new Result() { Count = repos.Count(), Description = project.Name })
                .ToList();

            return result.OrderByDescending(y => y.Count);
        }

        /// <summary>
        /// Get count of builds per project
        /// </summary>
        [HttpGet("buildCount")]
        public IEnumerable<Result> GetBuildCountPerProject()
        {
            var projects = GetListOfProjects();

            var result = (from project in projects
                          let repos = GetListOfBuilds(project.Name)
                          select new Result() { Count = repos.Count(), Description = project.Name })
                   .ToList();

            return result.OrderByDescending(y => y.Count);
        }

        /// <summary>
        /// Get count of builds per project
        /// </summary>
        [HttpGet("releaseCount")]
        public IEnumerable<Result> GetReleaseCountPerProject()
        {
            var projects = GetListOfProjects();

            var result = (from project in projects
                          let repos = GetListOfReleases(project.Name)
                          select new Result() { Count = repos.Count(), Description = project.Name })
                .ToList();

            return result.OrderByDescending(y => y.Count);
        }
    }
}
