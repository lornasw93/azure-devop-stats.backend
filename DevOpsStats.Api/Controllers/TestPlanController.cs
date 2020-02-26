using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]   
    public class TestPlanController : ControllerBase
    {
        private readonly IBaseQuery _query;

        public TestPlanController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get a list of test runs
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<object>> Get(string project)
        {
            return Ok(_query.GetList($"{project}/_apis/test/runs"));
        }

        //GET https://dev.azure.com/{organization}/{project}/_apis/testplan/plans?api-version=5.1-preview.1


        /// <summary>
        /// Get a list of test plans
        /// </summary>
        [HttpGet("testplans")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<object>> GetTestPlans(string project)
        {
            return Ok(_query.GetList($"{project}/_apis/testplan/plans"));
        }

        ///// <summary>
        ///// Get test run by project and Id
        ///// </summary>
        ///// <param name="project"></param>
        ///// <param name="runId"></param>
        ///// <returns></returns>
        //[HttpGet("/api/[controller]/{project}/{runId}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<object> GetById(string project, int runId)
        //{
        //    return Ok(_query.GetTestRunById(project, runId));
        //}

        ///// <summary>
        ///// Get a list of test runs by project
        ///// </summary>
        ///// <param name="project"></param>
        ///// <returns></returns>
        //[HttpGet("/api/[controller]/{project}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<object> GetAll(string project)
        //{
        //    return Ok(_query.GetTestRuns(project));
        //}

        ///// <summary>
        ///// Get count of test runs by project
        ///// </summary>
        ///// <param name="project"></param>
        ///// <returns></returns>
        //[HttpGet("count")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<ListCount> GetCount(string project)
        //{
        //    var url = $"{ResourceUrlConstants.TestPlanUrl}/{project}";

        //    return Ok(_query.GetCount(url));
        //}
    }
}
