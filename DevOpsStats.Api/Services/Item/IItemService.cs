using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Services.Item
{
    public interface IItemService<T> where T : ListObject
    {
        Task<ListObject> Item(string resourceUrl);
    }
}
