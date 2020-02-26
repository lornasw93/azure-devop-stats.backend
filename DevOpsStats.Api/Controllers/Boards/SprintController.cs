using System;
using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Boards.Sprint;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Controllers.Boards
{
    [Produces("application/json")]
    [Route("api/boards/[controller]")]
    [ApiController]
    public class SprintController : BaseController
    {
        protected override string ResourceName => $"{Api}/work/teamsettings/iterations";

        private readonly IBaseQuery _query;

        public SprintController(IBaseQuery query) : base(query)
        {
            _query = query;
        }

        /// <summary>
        /// Get a sprint/iteration by project, team and Id
        /// </summary>
        [HttpGet("/api/boards/[controller]/{project}/{team}/{iterationId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Sprint> Get(string project, string team, string iterationId)
        {
            var url = $"{project}/{team}/{ResourceName}/{iterationId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get a sprint/iteration list by project and team
        /// </summary>
        [HttpGet("/api/boards/[controller]/{project}/{team}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Sprint>> Get(string project, string team)
        {
            var url = $"{project}/{team}/{ResourceName}";

            return Ok(_query.GetList(url));
        }



        /// <summary>
        /// Get list of teams
        /// </summary>
        [HttpGet("listOfTeams")]
        public ActionResult<ValueList<object>> GetTeamsByProject(string project)
        {
            var url = $"{Api}/projects/{project}/teams";

            return Ok(_query.GetList(url));
        }



        //[HttpGet("teamPro")]
        //public Project a(string projectId)
        //{
        //    //GET https://dev.azure.com/{organization}/{project}/{team}/_apis/work/teamsettings/iterations
             
        //    var project = $"{Api}/projects/{projectId}";

        //    var item = _query.GetItem(project);


        //    var xx = JsonConvert.DeserializeObject<Project>(item.Result.ToString());





        //}






        private Iteration GetLatestSprint(string project, string team)
        {
            var item = _query.GetItem($"{project}/{team}/_apis/work/teamsettings/iterations?timeframe=current");

            return item.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<Iteration>(item.Result.ToString()) : null;
        }

        ///// <summary>
        ///// Get a list of work items in a sprint/iteration by project, team and iteration Id
        ///// </summary>
        //[HttpGet("/api/boards/[controller]/{project}/{team}/{iterationId}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<ValueList<object>> Get(string project, string team, Guid iterationId)
        //{
        //    var url = $"{project}/{team}/{ResourceName}/{iterationId}/workitems";

        //    return Ok(_query.GetList(url));
        //} 
    }
}
