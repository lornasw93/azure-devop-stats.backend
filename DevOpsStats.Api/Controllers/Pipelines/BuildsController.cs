using System.Globalization;
using System.Linq;
using System.Net;
using DevOpsStats.Api.Constants;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Pipelines.Build;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Route("api/pipelines/[controller]")]
    [ApiController]
    public class BuildsController : BaseController
    {
        protected override string ResourceName => $"{Api}/build/builds";

        private readonly IBaseQuery _query;

        public BuildsController(IBaseQuery query) : base(query)
        {
            _query = query;
        }

        /// <summary>
        /// Get build by project and build Id
        /// </summary>
        [HttpGet("/api/pipelines/[controller]/{project}/{buildId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Build> Get(string project, string buildId)
        {
            var url = $"{project}/{ResourceName}/{buildId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get build count
        /// </summary>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<int> GetCount(string project)
        {
            var url = $"{project}/{ResourceName}";

            return Ok(_query.GetCount(url));
        }

        /// <summary>
        /// Get list of builds by project
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Build>> Get(string project)
        {
            var url = $"{project}/{ResourceName}";
            return Ok(_query.GetList(url));
        }

        /// <summary>
        /// Builds grouped by month
        /// </summary>
        [HttpGet("/api/pipelines/[controller]/chart/byMonth/{project}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public Chart GetBuildsByMonthChart(string project)
        {
            var builds = GetListOfBuilds(project);

            return new Chart
            {
                Name = "Builds",
                Series = builds.GroupBy(o => new { o.FinishTime.Month, o.FinishTime.Year })
                               .Select(g => new { g.Key.Month, g.Key.Year, Count = g.Count() })
                               .OrderBy(a => a.Year)
                               .ThenBy(a => a.Month)
                               .Select(g => new Series()
                               {
                                   Value = g.Count,
                                   Name = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(g.Month)} {g.Year}"
                               })
            };
        }

        /// <summary>
        /// Builds grouped by request
        /// </summary>
        [HttpGet("/api/pipelines/[controller]/chart/byRequest/{project}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public Chart GetBuildsByRequestChart(string project)
        {
            var list = GetListOfBuilds(project);

            return new Chart
            {
                Name = "Builds",
                Series = list.GroupBy(o => new { o.RequestedFor.DisplayName })
                    .Select(g => new { g.Key.DisplayName, Count = g.Count() })
                    .Select(g => new Series()
                    {
                        Value = g.Count,
                        Name = g.DisplayName
                    })
            };
        }

        /// <summary>
        /// Builds grouped by result
        /// </summary>
        [HttpGet("/api/pipelines/[controller]/chart/byResult/{project}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public Chart GetBuildsByResultChart(string project)
        {
            var list = GetListOfBuilds(project);

            return new Chart
            {
                Name = "Builds",
                Series = list.GroupBy(o => new { o.Result })
                    .Select(g => new { g.Key.Result, Count = g.Count() })
                    .OrderBy(a => a.Result)
                    .Select(g => new Series()
                    {
                        Value = g.Count,
                        Name = g.Result
                    })
            };
        } 
    }
}
