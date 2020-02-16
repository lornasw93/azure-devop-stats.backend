using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Release;
using DevOpsStats.Api.Services; 
using DevOpsStats.Api.Services.Item;

namespace DevOpsStats.Api.Queries.Pipelines.Releases
{
    public class ReleasesQuery : IReleasesQuery
    {
        private readonly IDevOpsService _devOpsService;
        private readonly IItemService _service;

        public ReleasesQuery(IDevOpsService devOpsService, IItemService service)
        {
            _devOpsService = devOpsService;
            _service = service;
        }

        public Task<Release> Execute(string project, int releaseId)
        {
            return _devOpsService.GetRelease(project, releaseId);
        }

        public Task<ListObject> Execute(string project)
        {
            return _service.List($"{project}/_apis/release/releases");
        }

        public Task<ListCount> Count(string project)
        {
            return _service.Count($"{project}/_apis/release/releases");
        }
    }
}
