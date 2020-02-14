using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Release;
using DevOpsStats.Api.Queries.Pipelines.Releases;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        /// <remarks>
        /// </remarks>
        /// <returns>A list of builds</returns>
        /// <response code="200">Returns list of releases</response>
        /// <response code="400">If release list is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet]
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
        /// <response code="200">Returns build info</response>
        /// <response code="400">If release is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet("{releaseId:int}")]
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
        [Microsoft.AspNetCore.Mvc.HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.Count(project));
        }
    }
}