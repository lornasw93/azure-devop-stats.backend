using System.Threading.Tasks;
using DevOpsStats.Api.Models.DevOps;

namespace DevOpsStats.Api.Services.Count
{
    public interface ICountService<T> where T : ListCount
    {
        Task<ListCount> Count(string resourceUrl);
    }
}
