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
