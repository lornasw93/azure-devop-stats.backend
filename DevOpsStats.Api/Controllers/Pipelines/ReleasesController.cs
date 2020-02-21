using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Pipelines.Release;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Route("api/pipelines/[controller]")]
    [ApiController]
    public class ReleasesController : BaseController
    {
        protected override string ResourceName => $"{Api}/release/releases";

        private readonly IBaseQuery _query;

        public ReleasesController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get release info by project and release Id
        /// </summary> 
        [HttpGet("/api/pipelines/[controller]/{project}/{releaseId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(string project, string releaseId)
        {
            var url = $"{project}/{ResourceName}/{releaseId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get releases count
        /// </summary>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            var url = $"{project}/{ResourceName}";

            return Ok(_query.GetCount(url));
        }

        /// <summary>
        /// Get list of releases by project
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Release>> Get(string project)
        {
            var url = $"{project}/{ResourceName}";

            return Ok(_query.GetList(url));
        }
    }
}
