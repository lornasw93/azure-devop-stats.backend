using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public ProjectsController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get project info by name or Id
        /// </summary>
        /// <returns>A project</returns>
        /// <response code="200">Returns project info</response>
        /// <response code="400">If project is null</response>
        [HttpGet("/api/[controller]/{project}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Project> Get(string project)
        {
            var url = $"{ResourceUrlConstants.ProjectUrl}/{project}";

            return Ok(_query.GetItem(url));
        }
        
        /// <summary>
        /// Get project count
        /// </summary>
        /// <returns>Project count</returns>
        /// <response code="200">Returns project count</response>
        /// <response code="400">If project list is null</response>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            var url = $"{ResourceUrlConstants.ProjectUrl}/{project}";

            return Ok(_query.GetCount(url));
        }

        /// <summary>
        /// Get all projects in the organization that the authenticated user has access to
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Project>> Get()
        {
            return Ok(_query.GetList(ResourceUrlConstants.ProjectUrl));
        }
    }
}
