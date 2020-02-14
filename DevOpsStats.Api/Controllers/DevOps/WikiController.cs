using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Models.DevOps.Wiki;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.DevOps
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/devOps/[controller]")]
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
        public ActionResult<WikiList> Get(string project)
        {
            return Ok(_devOpsService.GetWiki(project));
        }
    }
}