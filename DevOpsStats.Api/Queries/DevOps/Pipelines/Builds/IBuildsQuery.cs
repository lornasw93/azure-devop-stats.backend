using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.DevOps;
using DevOpsStats.Api.Models.DevOps.Build;

namespace DevOpsStats.Api.Queries.DevOps.Pipelines.Builds
{
    public interface IBuildsQuery
    {
        Task<Build> Execute(string project, int buildId);
        Task<ValueList<Build>> Execute(string project);
        Task<ListCount> Count(string project);
    }
}
