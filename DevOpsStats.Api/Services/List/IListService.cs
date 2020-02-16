using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Services.List
{
    public interface IListService<T> where T : ListObject
    {
        Task<ListObject> List(string resourceUrl); 
    }
}
