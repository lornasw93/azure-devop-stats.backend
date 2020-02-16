using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Git.PullRequest;
using DevOpsStats.Api.Queries.Repos.PullRequests; 
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController]
    public class PullRequestsController : ControllerBase
    {
        private readonly IPullRequestsQuery _query;

        public PullRequestsController(IPullRequestsQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get list of pull requests
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<PullRequest>> Get(string project)
        {
            return Ok(_query.Execute(project));
        }

        /// <summary>
        /// Pull requests count
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.Count(project));
        }
    }
}
