using System.Collections.Generic;
using System.Linq;
using DevOpsStats.Api.Models.Pipelines.Build;
using DevOpsStats.Api.Models.Pipelines.Release;
using DevOpsStats.Api.Models.Project;
using DevOpsStats.Api.Models.Repos;
using DevOpsStats.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevOpsStats.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected string Api = "_apis";

        protected abstract string ResourceName { get; }

        private readonly IBaseQuery _query;

        protected BaseController(IBaseQuery query)
        {
            _query = query;
        }

        internal Project GetProject(string projectId)
        {
            var item = _query.GetItem($"{Api}/projects/{projectId}");

            return item.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<Project>(item.Result.ToString()) : null;
        }

        internal IEnumerable<Project> GetCertainProjects()
        {
            var projectIds = new List<string>()
            {
                "d3f6df63-8bb5-491f-8353-bd21bc0cf12b", //msw2
                "9e364b7e-c540-4664-9d44-2c48715bdd62", //fpmcore
                "89fd6ae8-0028-4e3e-ae01-cc2bfe58b9f8", //identityserver
            };

            return (from id in projectIds
                    select _query.GetItem($"{Api}/projects/{id}")
                into item
                    where item.IsCompletedSuccessfully
                    select JsonConvert.DeserializeObject<Project>(item.Result.ToString())).ToList();
        }


        internal IEnumerable<Project> GetListOfProjects()
        {
            var list = new List<Project>();

            var itemList = _query.GetList($"{Api}/projects");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Project>>(itemList.Result.List.ToString());

            return list;
        }

        internal IEnumerable<Repo> GetListOfRepos(string project)
        {
            var list = new List<Repo>();

            var itemList = _query.GetList($"{project}/{Api}/git/repositories");

            if (itemList.IsCompletedSuccessfully)
            {

                list = JsonConvert.DeserializeObject<List<Repo>>(itemList.Result.List.ToString());
               
                //foreach (var item in list)
                //{
                //    item.PushCount = GetPushCountForRepo(project, item.Id);
                //}
                 
            }

            return list;
        }
         

        private int GetPushCountForRepo(string project, string repoId)
        {
            var count = _query.GetCount($"{project}/_apis/git/repositories/{repoId}/pushes");

            return count.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(count.Result.Count.ToString()) : 0;
        }













        internal IEnumerable<Build> GetListOfBuilds(string project)
        {
            var list = new List<Build>();

            var itemList = _query.GetList($"{project}/{Api}/build/builds");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Build>>(itemList.Result.List.ToString());

            return list;
        }
        internal IEnumerable<Release> GetListOfReleases(string project)
        {
            var list = new List<Release>();

            var itemList = _query.GetList($"{project}/{Api}/release/releases");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Release>>(itemList.Result.List.ToString());

            return list;
        }

        internal IEnumerable<Deployment> GetListOfDeployments(string project)
        {
            var list = new List<Deployment>();

            var itemList = _query.GetList($"{project}/{Api}/release/deployments");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<Deployment>>(itemList.Result.List.ToString());

            return list;
        }

        internal IEnumerable<PullRequest> GetPullRequestsByStatus(string project, string repositoryId, string status)
        {
            var list = new List<PullRequest>();

            var itemList = _query.GetList($"{project}/{Api}/git/repositories/{repositoryId}/pullRequests?searchCriteria.status={status}");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<PullRequest>>(itemList.Result.List.ToString());

            return list;
        }

        internal int GetPullRequestsByStatus(string project, string status)
        {
            var repos = GetListOfRepos(project);
       
            return repos.Select(repo => _query
                 .GetCount($"{project}/{Api}/git/repositories/{repo.Id}/pullRequests?searchCriteria.status={status}"))
             .Select(itemList => itemList.IsCompletedSuccessfully ? JsonConvert.DeserializeObject<int>(itemList.Result.Count.ToString()) : 0)
             .Sum();
        }
         
        internal IEnumerable<object> GetPullRequestListByStatus(string project, string status)
        {
            var repos = GetListOfRepos(project);

            return repos.Select(repo => _query
                    .GetList($"{project}/{Api}/git/repositories/{repo.Id}/pullRequests?searchCriteria.status={status}"))
                .Select(itemList => itemList.IsCompletedSuccessfully
                    ? JsonConvert.DeserializeObject<IEnumerable<object>>(itemList.Result.List.ToString())
                    : null);
        }

        internal int GetPullRequestsByReviewerVote(string project, string repositoryId, int vote)
        {
            var list = new List<PullRequest>();

            var itemList = _query.GetList($"{project}/{Api}/git/repositories/{repositoryId}/pullRequests?searchCriteria.status=all");

            if (itemList.IsCompletedSuccessfully)
                list = JsonConvert.DeserializeObject<List<PullRequest>>(itemList.Result.List.ToString());

            return list.Select(item => item.Reviewers)
                .Sum(reviewers => reviewers
                    .Count(reviewer => reviewer.Vote == vote));
        }
    }
}
