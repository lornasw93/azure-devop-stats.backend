using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Release;

namespace DevOpsStats.Api.Queries.Pipelines.Releases
{
    public interface IReleasesQuery
    {
        Task<Release> Execute(string project, int buildId);
        Task<object> Execute(string project);
        Task<ListCount> Count(string project);
    }
}
