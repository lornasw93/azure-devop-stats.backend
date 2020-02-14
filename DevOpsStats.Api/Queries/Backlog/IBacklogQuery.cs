using System.Threading.Tasks;

namespace DevOpsStats.Api.Queries.Backlog
{
    public interface IBacklogQuery
    {
        Task<object> Execute(string project, string team);
    }
}
