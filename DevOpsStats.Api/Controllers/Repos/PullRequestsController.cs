using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Git.PullRequest;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

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
        /// Get a pull request by project and pull request Id
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
        /// Get a pull request by project, repository Id and pull request Id
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
        /// Pull requests count by project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.GetCount($"{ResourceUrlConstants.PullRequestUrl}/{project}"));
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
            return Ok(_query.GetList($"{ResourceUrlConstants.PullRequestUrl}/{project}"));
        }
    }
}
