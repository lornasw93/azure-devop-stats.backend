using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models; 
using DevOpsStats.Api.Models.Repos;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController]
    public class ReposController : BaseController
    {
        protected override string ResourceName => $"{Api}/git/repositories";
          
        private readonly IBaseQuery _query;

        public ReposController(IBaseQuery query) : base(query)
        {
            _query = query;
        }

        /// <summary>
        /// Get repo by project and repo Id
        /// </summary>
        [HttpGet("/api/repos/[controller]/{project}/{repositoryId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Repo> Get(string project, string repositoryId)
        { 
            return Ok(_query.GetItem($"{project}/{ResourceName}/{repositoryId}"));
        }
  
        /// <summary>
        /// Get repository count by project
        /// </summary>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.GetCount($"{project}/{ResourceName}"));
        }

        /// <summary>
        /// Get list of repos by project
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Repo>> Get(string project)
        {
            return Ok(_query.GetList($"{project}/{ResourceName}"));
        }
         
        [HttpGet("teams")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetTeams(string project)
        {
            return Ok(_query.GetCount($"_apis/projects/{project}/teams"));
        }
         
        //[HttpGet("teamIteration")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<ValueList<object>> GetTeamIteration(string project,string team)
        //{
        //    return Ok(_query.GetList($"{project}/{team}/_apis/work/teamsettings/iterations"));
        //}
        }
}