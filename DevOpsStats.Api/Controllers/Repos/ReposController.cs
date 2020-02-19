using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models; 
using DevOpsStats.Api.Models.Repos;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public ReposController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get repo by project and repo Id
        /// </summary>
        /// <param name="project"></param>
        /// <param name="repositoryId"></param>
        /// <returns></returns>
        [HttpGet("/api/repos/[controller]/{project}/{repositoryId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Repo> Get(string project, string repositoryId)
        { 
            return Ok(_query.GetItem($"{project}/{ResourceUrl.RepoUrl}/{repositoryId}"));
        }
  
        /// <summary>
        /// Get repository count by project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.GetCount($"{project}/{ResourceUrl.RepoUrl}"));
        }

        /// <summary>
        /// Get list of repos by project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Repo>> Get(string project)
        {
            return Ok(_query.GetList($"{project}/{ResourceUrl.RepoUrl}"));
        } 
    }
}