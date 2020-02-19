using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Models.Repos;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController]
    public class PullRequestsController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public PullRequestsController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get pull request by project and pull request Id
        /// </summary>
        /// <returns>Pull request</returns>
        /// <response code="200">Returns pull request</response>
        /// <response code="400">If pull request is null</response>
        [HttpGet("/api/repos/[controller]/{project}/{pullRequestId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<PullRequest> Get(string project, string pullRequestId)
        {
            var url = $"{project}/apis_/git/repositories/pullrequests/{pullRequestId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get pull request by project, repository Id and pull request Id
        /// </summary>
        /// <returns>Pull request</returns>
        /// <response code="200">Returns pull request</response>
        /// <response code="400">If pull request is null</response>
        [HttpGet("/api/repos/[controller]/{project}/{repositoryId}/{pullRequestId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<PullRequest> Get(string project, string repositoryId, string pullRequestId)
        {
            var url = $"{project}/apis_/git/repositories/{repositoryId}/pullrequests/{pullRequestId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get pull request count by project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.GetCount($"{ResourceUrl.PullRequestUrl}/{project}"));
        }

        /// <summary>
        /// Get list of pull requests by project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<PullRequest>> Get(string project)
        {
            return Ok(_query.GetList($"{ResourceUrl.PullRequestUrl}/{project}"));
        }

        [HttpGet("project")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public void Get()
        {
            // foreach project, get pull requests

            var projects = GetListOfProjects();
            if (!projects.Any())
                return;

            var abandonedPullRequests = new List<Pr>();
            var activePullRequests = new List<Pr>();
            var allPullRequests = new List<Pr>();
            var completedPullRequests = new List<Pr>();

            foreach (var project in projects)
            {
                var repositories = GetListOfRepos(project.Name);
                if (!repositories.Any())
                    continue;

                foreach (var repo in repositories)
                {
                    abandonedPullRequests = GetPullRequestByRepoIdAndStatus(GetPullRequestsByStatus(repo.Id, PullRequestStatus.Abandoned));
                    activePullRequests = GetPullRequestByRepoIdAndStatus(GetPullRequestsByStatus(repo.Id, PullRequestStatus.Active));
                    allPullRequests = GetPullRequestByRepoIdAndStatus(GetPullRequestsByStatus(repo.Id, PullRequestStatus.All));
                    completedPullRequests = GetPullRequestByRepoIdAndStatus(GetPullRequestsByStatus(repo.Id, PullRequestStatus.Completed));
                }
            }
        }

        /// <summary>
        /// Get list of pull requests by repository Id and status
        /// </summary>
        /// <param name="repositoryId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("/api/repos/[controller]/{repositoryId}/{status}")]
        public ActionResult<ValueList<PullRequest>> GetBy(string repositoryId, string status)
        {
            var x = GetPullRequestByRepoIdAndStatus(GetPullRequestsByStatus(repositoryId, status));
            return Ok(x);
        }
         
        public class Pr
        {
            public string Repository { get; set; }
            public string Title { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreationDate { get; set; }
            public string Reviewer { get; set; }
            public int ReviewerCount { get; set; }
            public string Status { get; set; }
        }

        private List<Pr> GetPullRequestByRepoIdAndStatus(List<PullRequest> pullRequests)
        {
            var list = new List<Pr>();

            if (pullRequests.Any())
            {
                foreach (var pr in pullRequests)
                {
                    var createdBy = pr.CreatedBy.DisplayName.Split(' ').First();
                    var t = pr.Reviewers.Select(x => x.DisplayName.Split(' ').First());
                    var reviewer = string.Join(",", t);

                    var prrrrr = new PullRequest();

                    var p = new Pr()
                    {
                        Repository = pr.Repository.Name,
                        Title = pr.Title,
                        ReviewerCount = pr.Reviewers.Count,
                        CreationDate = pr.CreationDate,
                        Status = pr.Status,
                        CreatedBy = createdBy,
                        Reviewer = reviewer
                    };

                    list.Add(p);
                }
            }

            return list;
        }

        private List<Repo> GetListOfRepos(string project)
        {
            var list = new List<Repo>();

            var itemList = _query.GetList($"{project}/{ResourceUrl.RepoUrl}");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Repo>>(itemList.Result.List.ToString());

            return list;
        }

        private List<PullRequest> GetPullRequestsByStatus(string repositoryId, string status)
        {
            var list = new List<PullRequest>();

            var itemList = _query.GetList($"fpmcore/_apis/git/repositories/{repositoryId}/pullRequests?searchCriteria.status={status}");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<PullRequest>>(itemList.Result.List.ToString());

            return list;
        }

        private List<Project> GetListOfProjects()
        {
            var list = new List<Project>();

            var itemList = _query.GetList(ResourceUrl.ProjectUrl);

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Project>>(itemList.Result.List.ToString());

            return list;
        }

        private List<PullRequest> GetListOfPullRequests(string project)
        {
            var list = new List<PullRequest>();

            var itemList = _query.GetList($"{project}/{ResourceUrl.PullRequestUrl}");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<PullRequest>>(itemList.Result.List.ToString());

            return list;
        }
    }
}
