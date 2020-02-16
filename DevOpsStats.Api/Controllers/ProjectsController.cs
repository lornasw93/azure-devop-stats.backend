using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Get all projects in the organization that the authenticated user has access to
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Project>> Get()
        {
            return Ok(_devOpsService.GetProjects());
        }
    }
}