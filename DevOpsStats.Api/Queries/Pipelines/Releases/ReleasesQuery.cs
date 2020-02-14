using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Release;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Services.Count;

namespace DevOpsStats.Api.Queries.Pipelines.Releases
{
    public class ReleasesQuery : IReleasesQuery
    {
        private readonly IDevOpsService _devOpsService;
        private readonly ICountService<ListCount> _countService;

        public ReleasesQuery(IDevOpsService devOpsService, ICountService<ListCount> countService)
        {
            _devOpsService = devOpsService;
            _countService = countService;
        }

        public Task<Release> Execute(string project, int releaseId)
        {
            return _devOpsService.GetRelease(project, releaseId);
        }

        public Task<object> Execute(string project)
        {
            return _devOpsService.GetReleases(project);
        }

        public Task<ListCount> Count(string project)
        {
            return _countService.Count($"{project}/_apis/release/releases");
        }
    }
}
