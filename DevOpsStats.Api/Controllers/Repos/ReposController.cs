using System;
using System.Net; 
using DevOpsStats.Api.Models.Git.Repo;
using DevOpsStats.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController] 
    public class ReposController : ControllerBase
    {
        private readonly IDevOpsService _devOpsService;

        public ReposController(IDevOpsService devOpsService)
        {
            _devOpsService = devOpsService;
        }
         
        /// <summary>
        /// Get repo by project and repo Id
        /// </summary>
        /// <param name="project"></param>
        /// <param name="repoId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Repo> Get(string project, Guid repoId)
        {
            return Ok(_devOpsService.GetGitRepo(project, repoId));
        }
         
        ///// <summary>
        ///// Get list of repos by project
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<ValueList<Repo>> Get(string project)
        //{
        //    return Ok(_devOpsService.GetGitRepos(project));
        //}
    }
}