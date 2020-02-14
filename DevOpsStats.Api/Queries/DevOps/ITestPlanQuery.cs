using System.Threading.Tasks;
using DevOpsStats.Api.Models.DevOps.TestPlan;

namespace DevOpsStats.Api.Queries.DevOps
{
    public interface ITestPlanQuery
    {
        Task<TestPlanList> Execute(string project);
    }
}
