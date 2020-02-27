using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Get work items for iteration
        /// </summary>
        [HttpGet("/api/boards/[controller]/{project}/{team}/{iterationId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Sprint> Get(string project, string team, string iterationId)
        {
            var url = $"{project}/{team}/{ResourceName}/{iterationId}/workitems";

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
        /// Get current sprint
        /// </summary>
        [HttpGet("currentSprint")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public Sprint GetLatestSprint(string project, string team)
        {
            var list = _query.GetList($"{project}/{team}/_apis/work/teamsettings/iterations");
             
            if (!list.IsCompletedSuccessfully) 
                return null;
      
            var a = JsonConvert.DeserializeObject<IEnumerable<Sprint>>(list.Result.List.ToString()).ToList();
            return a.FirstOrDefault(x => x.Attribute.TimeFrame.ToLower().Equals("current"));
        }


        /// <summary>
        /// Get current sprint
        /// </summary>
        [HttpGet("pastSprintCount")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public int GetPastSprintCount(string project, string team)
        {
            var list = _query.GetList($"{project}/{team}/_apis/work/teamsettings/iterations");

            if (!list.IsCompletedSuccessfully)
                return 0;

            var a = JsonConvert.DeserializeObject<IEnumerable<Sprint>>(list.Result.List.ToString()).ToList();



            var x = a.Where(x => x.Attribute.TimeFrame.ToLower().Equals("past"));

            return a.Count(x => x.Attribute.TimeFrame.ToLower().Equals("past"));
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

    }
}
