using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Overview.Wiki;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WikiController : BaseController
    {
        protected override string ResourceName => $"{Api}/wiki/wikis";

        private readonly IBaseQuery _query;
        
        public WikiController(IBaseQuery query) : base(query)
        {
            _query = query;
        }

        /// <summary>
        /// Gets the wiki corresponding to the wiki name or Id
        /// </summary>
        [HttpGet("/api/[controller]/{project}/{wikiIdentifer}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Wiki> Get(string project, string wikiIdentifier)
        {
            var url = $"{project}/{ResourceName}/{wikiIdentifier}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Gets all wikis in a project or collection
        /// </summary>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Wiki>> Get(string project)
        {
            var url = $"{project}/{ResourceName}";

            return Ok(_query.GetList(url));
        }
    }
}
