using System;
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
    public class SprintController : ControllerBase
    {
        private readonly IDevOpsService _service;

        public SprintController(IDevOpsService service)
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
