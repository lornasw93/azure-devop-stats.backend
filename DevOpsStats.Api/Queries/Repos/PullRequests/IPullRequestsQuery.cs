using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Queries.Repos.PullRequests
{
    public interface IPullRequestsQuery
    {
        Task<object> Execute(string project);
        Task<ListCount> Count(string project);
    }
}
