using DevOpsStats.Api.Queries.DevOps;
using DevOpsStats.Api.Queries.DevOps.Backlog;
using DevOpsStats.Api.Queries.DevOps.Pipelines.Builds;
using DevOpsStats.Api.Queries.DevOps.Pipelines.Releases;
using DevOpsStats.Api.Queries.DevOps.Projects;
using DevOpsStats.Api.Queries.DevOps.Repos.PullRequests;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Services.BackLog;
using DevOpsStats.Api.Services.Count;
using DevOpsStats.Api.Services.TestPlan;
using DevOpsStats.Api.Models.DevOps;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOpsStats.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            AddQueries(services);
            AddServices(services);

            return services;
        }

        private static void AddQueries(IServiceCollection services)
        {
            services.AddTransient<IBuildsQuery, BuildsQuery>();
            services.AddTransient<IReleasesQuery, ReleasesQuery>();
            services.AddTransient<IProjectsQuery, ProjectsQuery>();
            services.AddTransient<IPullRequestsQuery, PullRequestsQuery>();
            services.AddTransient<ITestPlanQuery, TestPlanQuery>();
            services.AddTransient<IBacklogQuery, BacklogQuery>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<ICountService<ListCount>, CountService<ListCount>>();
            services.AddTransient<IDevOpsService, DevOpsService>();
            services.AddTransient<ITestPlanService, TestPlanService>();
            services.AddTransient<IBacklogService, BacklogService>();
        }
    }
}
