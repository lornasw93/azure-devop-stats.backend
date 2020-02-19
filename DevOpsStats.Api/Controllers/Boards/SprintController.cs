using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Boards.Sprint;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Boards
{
    [Produces("application/json")]
    [Route("api/boards/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public SprintController(IBaseQuery query)
        {
            _query = query;
        }
        
        /// <summary>
        /// Get a sprint/iteration by project, team and Id
        /// </summary>
        /// <param name="project"></param>
        /// <param name="team"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/boards/[controller]/{project}/{team}/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Sprint> Get(string project, string team, string id)
        { 
            return Ok(_query.GetItem($"{ResourceUrl.SprintUrl}/{project}/{team}/{id}"));
        }

        /// <summary>
        /// Get a sprint/iteration list by project and team
        /// </summary>
        /// <param name="project"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Sprint>> Get(string project, string team)
        {
            return Ok(_query.GetList($"{ResourceUrl.SprintUrl}/{project}/{team}"));
        }
    }
}
