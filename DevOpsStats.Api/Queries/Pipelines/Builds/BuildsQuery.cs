using System.Net.Http;
using System.Threading.Tasks;
using DevOpsStats.Api.Models;

namespace DevOpsStats.Api.Queries.Pipelines.Builds
{
    public class BuildsQuery : BaseService, IBuildsQuery
    {
        protected override string ResourceUrl => "_apis/build/builds";

        public BuildsQuery(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public Task<object> GetItem(string project, string buildId)
        {
            return Item($"{project}/{ResourceUrl}/{buildId}");
        }

        public Task<ListCount> GetCount(string project)
        {
            return Count($"{project}/{ResourceUrl}");
        }

        public Task<ListObject> GetList(string project)
        {
            return List($"{project}/{ResourceUrl}");
        } 
    }
}
