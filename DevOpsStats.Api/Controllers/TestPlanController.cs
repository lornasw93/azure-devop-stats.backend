using System.Net;
using DevOpsStats.Api.Services.TestPlan;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]   
    public class TestPlanController : ControllerBase
    {
        private readonly ITestPlanService _service;

        public TestPlanController(ITestPlanService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get a test run by it's ID
        /// </summary>
        /// <param name="project"></param>
        /// <param name="runId"></param>
        /// <returns></returns>
        [HttpGet("{runId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> GetById(string project, int runId)
        {
            return Ok(_service.GetTestRunById(project, runId));
        }

        /// <summary>
        /// Get a list of test runs
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> GetAll(string project)
        {
            return Ok(_service.GetTestRuns(project));
        }

        /// <summary>
        /// Get test run statistics, used when we want to get summary of a run by outcome
        /// </summary>
        /// <param name="project"></param>
        /// <param name="runId"></param>
        /// <returns></returns>
        [HttpGet("stats")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> Get(string project, int runId)
        {
            return Ok(_service.GetTestRunStats(project, runId));
        }

        /// <summary>
        /// Get count of test runs
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> GetCount(string project)
        {
            return Ok(_service.GetTestRunsCount(project));
        }
    }
}
