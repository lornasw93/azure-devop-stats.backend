using System.Threading.Tasks;
using DevOpsStats.Api.Models; 
using DevOpsStats.Api.Models.TestPlan;

namespace DevOpsStats.Api.Services.TestPlan
{
    public interface ITestPlanService
    {
        Task<object> GetTestRuns(string project);
        Task<object> GetTestRunStats(string project, int runId);
        Task<object> GetTestRunById(string project, int runId);
        Task<ListCount> GetTestRunsCount(string project);
    }
}
