using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Wiki;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Overview
{
    [Produces("application/json")]
    [Route("api/overview/[controller]")]
    [ApiController]
    [Authorize]
    public class WikiController : ControllerBase
    {
        private readonly IDevOpsService _devOpsService;

        public WikiController(IDevOpsService devOpsService)
        {
            _devOpsService = devOpsService;
        }

        /// <summary>
        /// Gets all wikis in a project or collection
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Wiki>> Get(string project)
        {
            return Ok(_devOpsService.GetWiki(project));
        }
    }
}