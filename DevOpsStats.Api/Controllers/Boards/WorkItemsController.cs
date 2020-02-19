using System.Net;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Boards
{
    [Produces("application/json")]
    [Route("api/boards/[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        //private readonly IDevOpsService _service;

        //public WorkItemsController(IDevOpsService service)
        //{
        //    _service = service;
        //}

        //[Microsoft.AspNetCore.Mvc.HttpGet()]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<object> Get(string project)
        //{
        //    return Ok();
        //}
    }
}
