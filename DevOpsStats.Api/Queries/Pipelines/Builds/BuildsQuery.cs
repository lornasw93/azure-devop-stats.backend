using System.Threading.Tasks;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Services.Count;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Build;
using DevOpsStats.Api.Services.List;

namespace DevOpsStats.Api.Queries.Pipelines.Builds
{
    public class BuildsQuery : IBuildsQuery
    {
        private readonly IDevOpsService _service;
        private readonly ICountService<ListCount> _countService;
        private readonly IListService<ListObject> _listService;

        public BuildsQuery(IDevOpsService service, ICountService<ListCount> countService, IListService<ListObject> listService)
        {
            _service = service;
            _countService = countService;
            _listService = listService;
        }

        public Task<Build> Execute(string project, int buildId)
        {
            return _service.GetBuild(project, buildId);
        }

        public Task<ListObject> Execute(string project)
        {
            return _listService.List($"{project}/_apis/build/builds");
        }

        public Task<ListCount> Count(string project)
        {
            return _countService.Count($"{project}/_apis/build/builds");
        }
    }
}
