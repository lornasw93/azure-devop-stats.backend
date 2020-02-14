using System.Threading.Tasks;
using DevOpsStats.Api.Models.DevOps;

namespace DevOpsStats.Api.Queries.DevOps.Repos.PullRequests
{
    public interface IPullRequestsQuery
    {
        Task<object> Execute(string project);
        Task<ListCount> Count(string project);
    }
}
