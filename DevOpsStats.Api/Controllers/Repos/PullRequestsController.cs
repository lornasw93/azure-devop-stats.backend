using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Git.PullRequest; 
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController]
    public class PullRequestsController : ControllerBase
    {
        private readonly IGenericQuery _query;

        public PullRequestsController(IGenericQuery query)
        {
            _query = query;
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
            return Ok(_query.GetCount(ResourceUrlConstants.PullRequestUrl, project));
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
            return Ok(_query.GetList(ResourceUrlConstants.PullRequestUrl, project));
        } 
    }
}
