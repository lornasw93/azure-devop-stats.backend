using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.Project;

namespace DevOpsStats.Api.Queries.Projects
{
    public interface IProjectsQuery
    {
        Task<ProjectList> Execute();
        Task<ListCount> Count();
    }
}
