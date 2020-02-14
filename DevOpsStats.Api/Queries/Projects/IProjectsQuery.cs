using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Queries.Projects
{
    public interface IProjectsQuery
    {
        Task<object> Execute();
        Task<ListCount> Count();
    }
}
