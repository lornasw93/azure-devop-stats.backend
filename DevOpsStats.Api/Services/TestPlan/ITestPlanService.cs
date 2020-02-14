using System.Threading.Tasks;
using DevOpsStats.Api.Models.DevOps;
using DevOpsStats.Api.Models.DevOps.TestPlan;

namespace DevOpsStats.Api.Services.TestPlan
{
    public interface ITestPlanService
    {
        Task<TestPlanList> GetTestRuns(string project);
        Task<object> GetTestRunStats(string project, int runId);
        Task<object> GetTestRunById(string project, int runId);
        Task<ListCount> GetTestRunsCount(string project);
    }
}
