using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Queries.Projects
{
    public interface IProjectsQuery
    {
        Task<ListObject> Execute();
        Task<ListCount> Count();
    }
}
