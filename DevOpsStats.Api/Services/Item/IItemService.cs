using System.Threading.Tasks;
using DevOpsStats.Api.Models; 

namespace DevOpsStats.Api.Services.Item
{
    public interface IItemService
    {
        Task<ListObject> Item(string resourceUrl);
        Task<ListCount> Count(string resourceUrl);
        Task<ListObject> List(string resourceUrl);
    }
}