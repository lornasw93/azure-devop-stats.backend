using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using DevOpsStats.Api.Controllers.Repos;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Pipelines.Release;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Controllers.Pipelines
{
    [Produces("application/json")]
    [Route("api/pipelines/[controller]")]
    [ApiController]
    public class ReleasesController : BaseController
    {
        protected override string ResourceName => $"{Api}/release/releases";

        private readonly IBaseQuery _query;

        public ReleasesController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get release info by project and release Id
        /// </summary> 
        [HttpGet("/api/pipelines/[controller]/{project}/{releaseId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(string project, string releaseId)
        {
            var url = $"{project}/{ResourceName}/{releaseId}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get releases count
        /// </summary>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            var url = $"{project}/{ResourceName}";

            return Ok(_query.GetCount(url));
        }

        /// <summary>
        /// Get list of releases by project
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Release>> Get(string project)
        {
            var url = $"{project}/{ResourceName}";

            var x = _query.GetList(url);

            return Ok(x);
        }





        /// <summary>
        /// Releases grouped by month
        /// </summary>
        [HttpGet("/api/pipelines/[controller]/chart/byMonth/{project}")]
        public Chart GetReleasesByMonthChart(string project)
        {
            var releases = GetListOfReleases(project);

            return new Chart
            {
                Name = "Releases",
                Series = releases.GroupBy(o => new { o.CreatedOn.Month, o.CreatedOn.Year })
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
        /// Releases grouped by request
        /// </summary>
        [HttpGet("/api/pipelines/[controller]/chart/byRequest/{project}")]
        public Chart GetBuildsByRequestChart(string project)
        {
            var list = GetListOfReleases(project);
             
            return new Chart
            {
                Name = "Builds",
                Series = list.GroupBy(o => new { o.CreatedBy.DisplayName })
                    .Select(g => new { g.Key.DisplayName, Count = g.Count() })
                    .OrderBy(a => a.DisplayName)
                    .Select(g => new Series()
                    {
                        Value = g.Count,
                        Name = g.DisplayName.Forename()
                    })
            };
        }

        /// <summary>
        /// Releases grouped by result
        /// </summary>
        [HttpGet("/api/pipelines/[controller]/chart/byResult/{project}")]
        public Chart GetBuildsByResultChart(string project)
        {
            var list = GetListOfReleases(project);

            return new Chart
            {
                Name = "Releases",
                Series = list.GroupBy(o => new { o.Status })
                    .Select(g => new { g.Key.Status, Count = g.Count() })
                    .OrderBy(a => a.Status)
                    .Select(g => new Series()
                    {
                        Value = g.Count,
                        Name = g.Status
                    })
            };
        }

        private IEnumerable<Release> GetListOfReleases(string project)
        {
            var list = new List<Release>();

            var itemList = _query.GetList($"{project}/release/releases");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Release>>(itemList.Result.List.ToString());

            return list;
        }
    }
}
