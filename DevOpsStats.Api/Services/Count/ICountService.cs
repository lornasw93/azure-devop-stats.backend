using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Services.Count
{
    public interface ICountService<T> where T : ListCount
    {
        Task<ListCount> Count(string resourceUrl);
    }
}
