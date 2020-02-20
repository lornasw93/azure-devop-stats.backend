using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models; 
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController]
    public class CommitController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public CommitController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Retrieve git commits for a project
        /// </summary> 
        [HttpGet("/api/repos/[controller]/{project}/{repositoryId}/{commitId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> Get(string project, string repositoryId, string commitId)
        {
            return Ok(_query.GetItem($"{project}/{ResourceUrl.RepoUrl}/{repositoryId}/commits/{commitId}"));
        }

        /// <summary>
        /// Get git commit count
        /// </summary> 
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project, string repositoryId)
        {
            return Ok(_query.GetCount($"{project}/{ResourceUrl.RepoUrl}/{repositoryId}/commits"));
        }

        /// <summary>
        /// Get list of git commits by project and repository Id
        /// </summary> 
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<object>> Get(string project, string repositoryId)
        {
            return Ok(_query.GetList($"{project}/{ResourceUrl.RepoUrl}/{repositoryId}/commits"));
        }
    }
}
