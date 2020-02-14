using System;
using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IDevOpsService _devOpsService;

        public ProjectsController(IDevOpsService devOpsService)
        {
            _devOpsService = devOpsService;
        }


        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ProjectList> Get()
        {
            return Ok(_devOpsService.GetProjects());
        }
    }
}