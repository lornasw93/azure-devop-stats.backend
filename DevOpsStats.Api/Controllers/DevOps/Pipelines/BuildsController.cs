﻿using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Queries.DevOps.Pipelines.Builds;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.DevOps;
using DevOpsStats.Api.Models.DevOps.Build;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.DevOps.Pipelines
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/devOps/pipelines/[controller]")]
    [ApiController]
    [Authorize]
    public class BuildsController : ControllerBase
    {
        private readonly IBuildsQuery _query;

        public BuildsController(IBuildsQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get build info by project and build Id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>A build</returns>
        /// <response code="200">Returns build info</response>
        /// <response code="400">If build is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet("{buildId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Build> Get(string project, int buildId)
        {
            return Ok(_query.Execute(project, buildId));
        }

        /// <summary>
        /// Get list of builds by project
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Builds
        ///     {
        ///        "count": 1,
        ///        "value": [{
        ///         {
        ///           "id": 27280,
        ///           "result": "succeeded",
        ///           "buildNumber": "20200108.3", 
        ///           "requestedFor": {
        ///             "displayName": "Will Gale",
        ///             "uniqueName": "ERSITCOMM\\will.gale"
        ///           },
        ///           "queueTime": "2020-01-08T14:07:36.2750555Z",
        ///           "startTime": "2020-01-08T14:07:36.7441269Z",
        ///           "finishTime": "2020-01-08T14:20:32.268442Z",
        ///           "_links": {
        ///             "badge": {
        ///               "href": "http://comsol-tfs01.ersitcomm.local:8080/tfs/ersdev/9e364b7e-c540-4664-9d44-2c48715bdd62/_apis/build/status/208"
        ///             }
        ///           }
        ///         }
        ///       }
        /// 
        /// </remarks>
        /// <returns>A list of builds</returns>
        /// <response code="200">Returns list of builds</response>
        /// <response code="400">If build list is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Build>> Get(string project)
        {
            return Ok(_query.Execute(project));
        }

        /// <summary>
        /// Get builds count
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Builds
        ///     {
        ///        "count": 123,
        ///     }
        /// 
        /// </remarks>
        /// <returns>Builds count</returns>
        /// <response code="200">Returns build count</response>
        /// <response code="400">If builds list is null</response>
        [Microsoft.AspNetCore.Mvc.HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.Count(project));
        }
    }
}