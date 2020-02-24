using System.Collections.Generic;
using System.Linq;
using System.Net;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Pipelines.Build;
using DevOpsStats.Api.Models.Pipelines.Release;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Models.Repos;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace DevOpsStats.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        protected override string ResourceName => $"{Api}/projects";

        private readonly IBaseQuery _query;

        public ProjectsController(IBaseQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get project
        /// </summary>
        [HttpGet("/api/[controller]/{project}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Project> Get(string project)
        {
            var url = $"{ResourceName}/{project}";

            return Ok(_query.GetItem(url));
        }

        /// <summary>
        /// Get project count
        /// </summary>
        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            var url = $"{ResourceName}/{project}";

            return Ok(_query.GetCount(url));
        }

        /// <summary>
        /// Get all projects in the organization that the authenticated user has access to
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ValueList<Project>> Get()
        {
            var projects = GetListOfProjects();

            foreach (var project in projects)
            {
                project.RepoCount = GetRepoCountForProject(project.Id);
                project.BuildCount = GetBuildCountForProject(project.Id);
                project.ReleaseCount = GetReleaseCountForProject(project.Id);
            }

            return Ok(projects);
        }




        private int GetRepoCountForProject(string id)
        {
            return GetListOfRepos(id).Count();
        }
        private int GetBuildCountForProject(string id)
        {  
            return GetListOfBuilds(id).Count();
        }
        private int GetReleaseCountForProject(string id)
        {
            return GetListOfReleases(id).Count();
        }








        /// <summary>
        /// Get count of repos per project
        /// </summary>
        [HttpGet("repoCount")]
        public IEnumerable<Result> GetRepoCountPerProject()
        {
            var projects = GetListOfProjects();

            var result = (from project in projects
                          let repos = GetListOfRepos(project.Name)
                          select new Result() { Count = repos.Count(), Description = project.Name })
                .ToList();

            return result.OrderByDescending(y => y.Count);
        }

        /// <summary>
        /// Get count of builds per project
        /// </summary>
        [HttpGet("buildCount")]
        public IEnumerable<Result> GetBuildCountPerProject()
        {
            var projects = GetListOfProjects();

            var result = (from project in projects
                          let repos = GetListOfBuilds(project.Name)
                          select new Result() { Count = repos.Count(), Description = project.Name })
                   .ToList();

            return result.OrderByDescending(y => y.Count);
        }

        /// <summary>
        /// Get count of builds per project
        /// </summary>
        [HttpGet("releaseCount")]
        public IEnumerable<Result> GetReleaseCountPerProject()
        {
            var projects = GetListOfProjects();

            var result = (from project in projects
                          let repos = GetListOfReleases(project.Name)
                          select new Result() { Count = repos.Count(), Description = project.Name })
                .ToList();

            return result.OrderByDescending(y => y.Count);
        }

        private IEnumerable<Project> GetListOfProjects()
        {
            var list = new List<Project>();

            var itemList = _query.GetList(ResourceName);

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Project>>(itemList.Result.List.ToString());

            return list;
        }

        private IEnumerable<Repo> GetListOfRepos(string project)
        {
            var list = new List<Repo>();

            var itemList = _query.GetList($"{project}/{Api}/git/repositories");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Repo>>(itemList.Result.List.ToString());

            return list;
        }

        private IEnumerable<Build> GetListOfBuilds(string project)
        {
            var list = new List<Build>();

            var itemList = _query.GetList($"{project}/{Api}/build/builds");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Build>>(itemList.Result.List.ToString());

            return list;
        }

        private IEnumerable<Release> GetListOfReleases(string project)
        {
            var list = new List<Release>();

            var itemList = _query.GetList($"{project}/_apis/release/releases");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Release>>(itemList.Result.List.ToString());

            return list;
        }
    }
}
