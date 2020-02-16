using System.Net;
using DevOpsStats.Api.Queries.Backlog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Boards
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/boards/[controller]")]
    [ApiController]
    [Authorize]
    public class BacklogController : ControllerBase
    {
        private readonly IBacklogQuery _query;

        public BacklogController(IBacklogQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// List all backlog levels
        /// </summary>
        /// <param name="project"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> GetAll(string project, string team)
        {
            return Ok(_query.Execute(project, team));
        }
    }
}