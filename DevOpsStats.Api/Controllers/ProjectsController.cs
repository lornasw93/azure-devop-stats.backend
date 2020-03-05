using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
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

        public ProjectsController(IBaseQuery query) : base(query)
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
            var projects = GetCertainProjects();

            foreach (var project in projects)
            {
                project.RepoCount = GetRepoCountForProject(project.Id);
                project.PullRequestCounts = GetPullRequestCounts(project.Id);
                project.BuildCounts = GetBuildCounts(project.Id);
                project.DeploymentCounts = GetDeploymentCounts(project.Id);
                project.TeamCount = GetTeamCount(project.Id);
                project.TestRunCount = GetTestRunCount(project.Id);
                project.TestPlanCount = GetTestPlanCount(project.Id);
            }

            return Ok(projects.OrderByDescending(y => y.Name));
        }

        private int GetTestPlanCount(string project)
        {
            var count = _query.GetCount($"{project}/_apis/testplan/plans");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        }
        private int GetTestRunCount(string project)
        {
            var count = _query.GetCount($"{project}/_apis/test/runs");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        }
        private int GetTeamCount(string projectId)
        {
            var count = _query.GetCount($"_apis/projects/{projectId}/teams");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        }
        private PullRequestCounts GetPullRequestCounts(string projectId)
        {
            var repos = GetListOfRepos(projectId);

            var approved = 0;
            var approvedWithSuggestions = 0;
            var noVote = 0;
            var waitingForAuthor = 0;
            var rejected = 0;

            foreach (var repo in repos)
            {
                approved = +GetPullRequestsByReviewerVote(projectId, repo.Id, Vote.Approved);
                approvedWithSuggestions = +GetPullRequestsByReviewerVote(projectId, repo.Id, Vote.ApprovedWithSuggestions);
                noVote = +GetPullRequestsByReviewerVote(projectId, repo.Id, Vote.NoVote);
                waitingForAuthor = +GetPullRequestsByReviewerVote(projectId, repo.Id, Vote.WaitingForAuthor);
                rejected = +GetPullRequestsByReviewerVote(projectId, repo.Id, Vote.Rejected);
            }
             
            var counts = new PullRequestCounts
            {
                CompletedCount = GetPullRequestsByStatus(projectId, PullRequestStatus.Completed),
                ActiveCount = GetPullRequestsByStatus(projectId, PullRequestStatus.Active),
                AbandonedCount = GetPullRequestsByStatus(projectId, PullRequestStatus.Abandoned),
                NotSetCount = GetPullRequestsByStatus(projectId, PullRequestStatus.NotSet),
                Approved = approved,
                ApprovedWithSuggestions = approvedWithSuggestions,
                NoVote = noVote,
                WaitingForAuthor = waitingForAuthor,
                Rejected = rejected
            };
             
            return counts;
        }

        private BuildCounts GetBuildCounts(string projectId)
        {
            var buildsList = GetListOfBuilds(projectId);
            if (buildsList != null)
            {
                return new BuildCounts
                {
                    BuildInProgressCount = buildsList.Count(l => l.Result.Equals(BuildStatus.InProgress)),
                    BuildFailedCount = buildsList.Count(l => l.Result.Equals(BuildResult.Failed)),
                    BuildCancelledCount = buildsList.Count(l => l.Result.Equals(BuildResult.Cancelled)),
                    BuildSucceededCount = buildsList.Count(l => l.Result.Equals(BuildResult.Succeeded))
                };
            }

            return null;
        }

        private DeploymentCounts GetDeploymentCounts(string projectId)
        {
            var releasesList = GetListOfDeployments(projectId);
            if (releasesList != null)
            {
                return new DeploymentCounts
                {
                    InProgressCount = releasesList.Count(l => l.Status.Equals(DeploymentStatus.InProgress)),
                    FailedCount = releasesList.Count(l => l.Status.Equals(DeploymentStatus.Failed)),
                    NotDeployedCount = releasesList.Count(l => l.Status.Equals(DeploymentStatus.NotDeployed)),
                    SucceededCount = releasesList.Count(l => l.Status.Equals(DeploymentStatus.Succeeded))
                };
            }

            return null;
        }

        /// <summary>
        /// Get list of backlogs
        /// </summary>
        [HttpGet("backlogs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<object>> GetBacklogs(string project, string team)
        {
            var url = $"{project}/{team}/_apis/work/backlogs";

            return Ok(_query.GetList(url));
        }

        //private int GetBuildCountForProject(string project)
        //{
        //    var count = _query.GetCount($"{project}/{Api}/build/builds");

        //    return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        //}
        //private int GetReleaseCountForProject(string project)
        //{
        //    var count = _query.GetCount($"{project}/{Api}/release/releases");

        //    return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        //}
         
        //private string GetDiff(DateTime date)
        //{
        //    var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
        //    var delta = Math.Abs(ts.TotalSeconds);

        //    if (delta < 1 * Minute)
        //        return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

        //    if (delta < 2 * Minute)
        //        return "a minute ago";

        //    if (delta < 45 * Minute)
        //        return ts.Minutes + " minutes ago";

        //    if (delta < 90 * Minute)
        //        return "an hour ago";

        //    if (delta < 24 * Hour)
        //        return ts.Hours + " hours ago";

        //    if (delta < 48 * Hour)
        //        return "yesterday";

        //    if (delta < 30 * Day)
        //        return ts.Days + " days ago";

        //    if (delta < 12 * Month)
        //    {
        //        var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
        //        return months <= 1 ? "one month ago" : months + " months ago";
        //    }

        //    var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
        //    return years <= 1 ? "one year ago" : years + " years ago";
        //}
         
        private int GetRepoCountForProject(string project)
        {
            var count = _query.GetCount($"{project}/{Api}/git/repositories");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
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

    public class Iteration
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attributes")]
        public Attribute Attributes { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
