using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Services;

namespace DevOpsStats.Api.Queries
{
    public class BaseQuery : BaseService, IBaseQuery
    {
        public BaseQuery(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public Task<object> GetItem(string resourceUrl)
        {
            return Item(resourceUrl);
        }

        public Task<ListCount> GetCount(string resourceUrl)
        {
            return Count(resourceUrl);
        }

        public Task<ListObject> GetList(string resourceUrl)
        {
            return List(resourceUrl);
        }
    }
}
