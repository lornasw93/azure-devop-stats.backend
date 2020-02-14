using System.Threading.Tasks;
using DevOpsStats.Api.Models.DevOps;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Services.Count;

namespace DevOpsStats.Api.Queries.DevOps.Repos.PullRequests
{
    public class PullRequestsQuery :  IPullRequestsQuery
    { 
        private readonly IDevOpsService _service;
        private readonly ICountService<ListCount> _countService;

        public PullRequestsQuery(IDevOpsService service, ICountService<ListCount> countService)
        {
            _service = service;
            _countService = countService;
        }

        public Task<object> Execute(string project)
        {
            return _service.GetPullRequestsByProject(project);
        }

        public Task<ListCount> Count(string project)
        {
            return _countService.Count($"{project}/_apis/git/pullrequests");
        }
    }
}
