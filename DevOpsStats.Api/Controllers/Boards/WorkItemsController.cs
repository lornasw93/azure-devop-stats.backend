using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Boards.WorkItem;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Boards
{
    [Produces("application/json")]
    [Route("api/boards/[controller]")]
    [ApiController]
    public class WorkItemsController : BaseController
    {
        protected override string ResourceName => $"{Api}/wik/workitems";

        private readonly IBaseQuery _query;

        public WorkItemsController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get build by project and build Id
        /// </summary>
        [HttpGet("/api/boards/[controller]/{project}/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<WorkItem> Get(string project, int id)
        {
            var url = $"{project}/{ResourceName}/{id}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get list of work items by project and Ids (max. 200 items). Pass in a comma string list i.e. 12345,6789
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<WorkItem>> Get(string project, string ids)
        {
            var url = $"{project}/{ResourceName}?ids={ids}";

            return Ok(_query.GetList(url));
        }
    }
}
