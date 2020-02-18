using System.Threading.Tasks;
using DevOpsStats.Api.Models; 

namespace DevOpsStats.Api.Queries.Pipelines.Builds
{
    public interface IBuildsQuery
    {
        Task<object> GetItem(string project, string buildId);
        Task<ListCount> GetCount(string project);
        Task<ListObject> GetList(string project);
    }
}
