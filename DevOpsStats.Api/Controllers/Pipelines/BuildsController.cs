using System.Net;
using System.Web.Http; 
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Build;
using DevOpsStats.Api.Queries.Pipelines.Builds;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/pipelines/[controller]")]
    [ApiController]
    [Authorize]
    public class BuildsController : ControllerBase
    {
        private readonly IBuildsQuery _query;

        public BuildsController(IBuildsQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get build info by project and build Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>A build</returns>
        /// <response code="200">Returns build info</response>
        /// <response code="400">If build is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet("{buildId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Build> Get(string project, int buildId)
        {
            return Ok(_query.Execute(project, buildId));
        }

        /// <summary>
        /// Get list of builds by project
        /// </summary>
        /// <returns>A list of builds</returns>
        /// <response code="200">Returns list of builds</response>
        /// <response code="400">If build list is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Build>> Get(string project)
        {
            return Ok(_query.Execute(project));
        }

        /// <summary>
        /// Get builds count
        /// </summary>
        /// <returns>Builds count</returns>
        /// <response code="200">Returns build count</response>
        /// <response code="400">If builds list is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.Count(project));
        }
    }
}
