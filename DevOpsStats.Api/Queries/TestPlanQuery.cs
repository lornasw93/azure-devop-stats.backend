using System.Threading.Tasks;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Models.TestPlan;
using DevOpsStats.Api.Services.TestPlan;

namespace DevOpsStats.Api.Queries
{
    public class TestPlanQuery : ITestPlanQuery
    {
        //private readonly ITestPlanService _service;

        //public TestPlanQuery(ITestPlanService service)
        //{
        //    _service = service;
        //}

        //public Task<object> Execute(string project)
        //{
        //    return _service.GetTestRuns(project);
        //}

        //public Task<object> Execute(string project, int runId)
        //{
        //    return _service.GetTestRunStats(project, runId);
        //}

        //public Task<object> ExecuteSingular(string project, int runId)
        //{
        //    return _service.GetTestRunById(project, runId);
        //}

        //public Task<ListCount> Count(string project)
        //{
        //    return _service.GetTestRunsCount(project);
        //}
    }
}
