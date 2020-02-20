using System.Net;
using DevOpsStats.Api.Constants;
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
        [HttpGet("/api/pipelines/[controller]/{project}/{buildId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Build> Get(string project, string buildId)
        { 
            var url = $"{ResourceUrl.BuildUrl}/{project}/{buildId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get build count
        /// </summary>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        { 
            return Ok(_query.GetCount($"{ResourceUrl.BuildUrl}/{project}"));
        }

        /// <summary>
        /// Get list of builds by project
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Build>> Get(string project)
        { 
            return Ok(_query.GetList($"{ResourceUrl.BuildUrl}/{project}"));
        }
    }
}
