using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api
{
    public interface IGenericQuery
    {
        Task<object> GetItem(string resourceUrl, string project, string id);
        Task<object> GetItem(string resourceUrl, string project);
        Task<ListCount> GetCount(string resourceUrl, string project);
        Task<ListObject> GetList(string resourceUrl, string project);
    }
}
