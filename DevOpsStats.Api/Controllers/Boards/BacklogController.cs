using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Boards
{
    [Produces("application/json")]
    [Route("api/boards/[controller]")]
    [ApiController]
    public class BacklogController : ControllerBase
    {
        private readonly IGenericQuery _query;

        public BacklogController(IGenericQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// List all backlog levels
        /// </summary>
        /// <param name="project"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> GetAll(string project, string team)
        {
            return Ok(_query.GetList(project, team));
        }
    }
}