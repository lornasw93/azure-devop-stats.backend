using System.Net;
using DevOpsStats.Api.Constants;
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
        /// Get project
        /// </summary>
        [HttpGet("/api/[controller]/{project}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Project> Get(string project)
        {
            var url = $"{ResourceUrl.ProjectUrl}/{project}";

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
            var url = $"{ResourceUrl.ProjectUrl}/{project}";

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
            return Ok(_query.GetList(ResourceUrl.ProjectUrl));
        }
    }
}
