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
    public class BuildsController : BaseController
    {
        protected override string ResourceName => $"{Api}/build/builds";

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
            var url = $"{project}/{ResourceName}/{buildId}";

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
            var url = $"{project}/{ResourceName}";

            return Ok(_query.GetCount(url));
        }

        /// <summary>
        /// Get list of builds by project
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Build>> Get(string project)
        {
            var url = $"{project}/{ResourceName}";

            return Ok(_query.GetList(url));
        }
    }
}
