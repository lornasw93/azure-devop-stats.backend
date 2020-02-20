using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Queries
{
    public interface IBaseQuery
    {
        Task<object> GetItem(string resourceUrl);
        Task<ListCount> GetCount(string resourceUrl);
        Task<RootObject> GetList(string resourceUrl);
    }
}
