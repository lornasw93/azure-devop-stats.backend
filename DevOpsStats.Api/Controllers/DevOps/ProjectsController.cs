using System;
using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Models.DevOps.Project;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.DevOps
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/devOps/[controller]")]
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