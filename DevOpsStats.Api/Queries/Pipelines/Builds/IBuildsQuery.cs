using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Build;

namespace DevOpsStats.Api.Queries.Pipelines.Builds
{
    public interface IBuildsQuery
    {
        Task<Build> Execute(string project, int buildId);
        Task<object> Execute(string project);
        Task<ListCount> Count(string project);
    }
}
