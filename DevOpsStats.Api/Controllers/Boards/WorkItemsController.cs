using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Boards
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/boards/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkItemsController : ControllerBase
    {
        private readonly IDevOpsService _service;

        public WorkItemsController(IDevOpsService service)
        {
            _service = service;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> Get(string project)
        {
            return Ok();
        }
    }
}
