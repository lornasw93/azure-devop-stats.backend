using System.Threading.Tasks;
using DevOpsStats.Api.Services.BackLog;

namespace DevOpsStats.Api.Queries.DevOps.Backlog
{
    public class BacklogQuery : IBacklogQuery
    {
        private readonly IBacklogService _service;

        public BacklogQuery(IBacklogService service)
        {
            _service = service;
        }

        public Task<object> Execute(string project, string team)
        {
            return _service.GetItems(project, team);
        }
    }
}
