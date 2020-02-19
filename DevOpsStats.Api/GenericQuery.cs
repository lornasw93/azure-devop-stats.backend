using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api
{
    public class GenericQuery : BaseService, IGenericQuery
    {
        public GenericQuery(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public Task<object> GetItem(string resourceUrl, string project, string id)
        {
            return Item($"{project}/{resourceUrl}/{id}");
        }

        public Task<object> GetItem(string resourceUrl, string project)
        {
            return Item($"{resourceUrl}/{project}");
        }

        public Task<ListCount> GetCount(string resourceUrl, string project)
        {
            return Count($"{project}/{resourceUrl}");
        }

        public Task<ListObject> GetList(string resourceUrl, string project)
        {
            return List(!string.IsNullOrWhiteSpace(project) ? $"{project}/{resourceUrl}" : resourceUrl);
        }
    }
}
