using System.Threading.Tasks;
using DevOpsStats.Api.Models.TestPlan;

namespace DevOpsStats.Api.Queries
{
    public interface ITestPlanQuery
    {
        Task<object> Execute(string project);
    }
}
