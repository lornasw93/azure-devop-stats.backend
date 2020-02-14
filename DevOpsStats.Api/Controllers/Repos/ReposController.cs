using System;
using System.Web.Http;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/repos[controller]")]
    [ApiController]
    [Authorize]
    public class ReposController : ControllerBase
    {
        private readonly IDevOpsService _devOpsService;

        public ReposController(IDevOpsService devOpsService)
        {
            _devOpsService = devOpsService;
        }

        /// <summary>
        /// Get list of repos
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult<ProjectList> Get()
        {
            return Ok();
        }
    }
}