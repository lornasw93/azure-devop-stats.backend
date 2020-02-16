using System.Threading.Tasks;
using DevOpsStats.Api.Models; 
using DevOpsStats.Api.Services.Count;
using DevOpsStats.Api.Services.List;

namespace DevOpsStats.Api.Queries.Projects
{
    public class ProjectsQuery : IProjectsQuery
    {
        private readonly ICountService<ListCount> _countService;
        private readonly IListService<ListObject> _listService;

        public ProjectsQuery(ICountService<ListCount> countService, IListService<ListObject> listService)
        {
            _countService = countService;
            _listService = listService;
        }

        public Task<ListObject> Execute()
        {
            return _listService.List("_apis/projects");
        }
         
        public Task<ListCount> Count()
        {
            return _countService.Count("_apis/projects");
        }
    }
}
