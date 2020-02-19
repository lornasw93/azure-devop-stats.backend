using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Pipelines.Release;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Route("api/pipelines/[controller]")]
    [ApiController]
    public class ReleasesController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public ReleasesController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get release info by project and release Id
        /// </summary> 
        /// <returns>A release</returns>
        /// <response code="200">Returns release info</response>
        /// <response code="400">If release is null</response>
        [HttpGet("/api/pipelines/[controller]/{project}/{releaseId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(string project, string releaseId)
        { 
            return Ok(_query.GetItem($"{ResourceUrlConstants.ReleaseUrl}/{project}/{releaseId}"));
        }

        /// <summary>
        /// Get releases count
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        { 
            return Ok(_query.GetCount($"{ResourceUrlConstants.BuildUrl}/{project}"));
        }

        /// <summary>
        /// Get list of releases by project
        /// </summary>
        /// <returns>A list of releases</returns>
        /// <response code="200">Returns list of releases</response>
        /// <response code="400">If release list is null</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Release>> Get(string project)
        {  
            return Ok(_query.GetList($"{ResourceUrlConstants.ReleaseUrl}/{project}"));
        }
    }
}
