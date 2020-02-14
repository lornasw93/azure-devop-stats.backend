using System.Threading.Tasks;

namespace DevOpsStats.Api.Services.BackLog
{
    public interface IBacklogService
    {
        Task<object> GetItems(string project, string team);
    }
}
