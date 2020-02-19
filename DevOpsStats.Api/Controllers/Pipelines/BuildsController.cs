using System.Net;
using DevOpsStats.Api.Models; 
using DevOpsStats.Api.Models.Pipelines.Build;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Route("api/pipelines/[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public BuildsController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get build by project and build Id
        /// </summary>
        /// <returns>A build</returns>
        /// <response code="200">Returns build info</response>
        /// <response code="400">If build is null</response>
        [HttpGet("/api/pipelines/[controller]/{project}/{buildId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Build> Get(string project, string buildId)
        { 
            var url = $"{ResourceUrlConstants.BuildUrl}/{project}/{buildId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get build count
        /// </summary>
        /// <returns>Builds count</returns>
        /// <response code="200">Returns build count</response>
        /// <response code="400">If builds list is null</response>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        { 
            return Ok(_query.GetCount($"{ResourceUrlConstants.BuildUrl}/{project}"));
        }

        /// <summary>
        /// Get list of builds by project
        /// </summary>
        /// <returns>A list of builds</returns>
        /// <response code="200">Returns list of builds</response>
        /// <response code="400">If build list is null</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Build>> Get(string project)
        { 
            return Ok(_query.GetList($"{ResourceUrlConstants.BuildUrl}/{project}"));
        }
    }
}
