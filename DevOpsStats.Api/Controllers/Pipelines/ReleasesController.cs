using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Release;
using DevOpsStats.Api.Queries.Pipelines.Releases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Route("api/pipelines/[controller]")]
    [ApiController] 
    public class ReleasesController : ControllerBase
    {
        private readonly IReleasesQuery _query;

        public ReleasesController(IReleasesQuery query)
        {
            _query = query;
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
            return Ok(_query.Execute(project));
        }

        /// <summary>
        /// Get release info by project and build Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>A release</returns>
        /// <response code="200">Returns release info</response>
        /// <response code="400">If release is null</response>
        [HttpGet("{releaseId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(string project, int releaseId)
        {
            return Ok(_query.Execute(project, releaseId));
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
            return Ok(_query.Count(project));
        }
    }
}