using System.Threading.Tasks;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Services.Count;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.DevOps;
using DevOpsStats.Api.Models.DevOps.Build;

namespace DevOpsStats.Api.Queries.DevOps.Pipelines.Builds
{
    public class BuildsQuery : IBuildsQuery
    {
        private readonly IDevOpsService _service;
        private readonly ICountService<ListCount> _countService;

        public BuildsQuery(IDevOpsService service, ICountService<ListCount> countService)
        {
            _service = service;
            _countService = countService;
        }

        public Task<Build> Execute(string project, int buildId)
        {
            return _service.GetBuild(project, buildId);
        }

        public Task<ValueList<Build>> Execute(string project)
        {
            return _service.GetBuilds(project);
        }

        public Task<ListCount> Count(string project)
        {
            return _countService.Count($"{project}/_apis/build/builds");
        }
    }
}
