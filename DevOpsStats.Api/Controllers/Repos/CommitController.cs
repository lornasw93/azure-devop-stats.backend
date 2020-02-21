using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Commit;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Route("api/repos/[controller]")]
    [ApiController]
    public class CommitController : BaseController
    {
        protected override string ResourceName => $"{Api}/git/repositories";

        private readonly IBaseQuery _query;

        public CommitController(IBaseQuery query)
        {
            _query = query;
        }
        
        /// <summary>
        /// Get count of git commits
        /// </summary> 
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project, string repositoryId)
        {
            var url = $"{project}/{ResourceName}/{repositoryId}/commits/";

            return Ok(_query.GetCount(url));
        }

        ///// <summary>
        ///// Retrieve list of git commits for a project
        ///// </summary> 
        //[HttpGet("/api/repos/[controller]/{project}/{repositoryId}")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public ActionResult<ValueList<object>> Get(string project, string repositoryId)
        //{
        //    var url = $"{project}/{ResourceName}/{repositoryId}/commits";

        //    return Ok(_query.GetList(url));
        //}

        /// <summary>
        /// Retrieve list of git commits by author within a repository
        /// </summary> 
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Commit>> Get(string repositoryId, string author)
        {
            var url = $"{ResourceName}/{repositoryId}/commits?searchCriteria.author={author}";

            return Ok(_query.GetList(url));
        }
    }
}
