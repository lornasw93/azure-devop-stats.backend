using System.Threading.Tasks;
using DevOpsStats.Api.Models.DevOps;
using DevOpsStats.Api.Models.DevOps.Project;

namespace DevOpsStats.Api.Queries.DevOps.Projects
{
    public interface IProjectsQuery
    {
        Task<ProjectList> Execute();
        Task<ListCount> Count();
    }
}
