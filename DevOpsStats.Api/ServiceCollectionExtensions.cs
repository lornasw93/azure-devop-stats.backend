using DevOpsStats.Api.Models;
using DevOpsStats.Api.Services;
using DevOpsStats.Api.Services.BackLog;
using DevOpsStats.Api.Services.Count;
using DevOpsStats.Api.Services.Item;
using DevOpsStats.Api.Services.List;
using DevOpsStats.Api.Services.TestPlan;
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
            services.AddTransient<IGenericQuery, GenericQuery>();
        }

        private static void AddServices(IServiceCollection services)
        {
            //services.AddTransient<IItemService, ItemService>();
            //services.AddTransient<ICountService<ListCount>, CountService<ListCount>>();
            //services.AddTransient<IDevOpsService, DevOpsService>();
            //services.AddTransient<IListService<ListObject>, ListService<ListObject>>();
            //services.AddTransient<ITestPlanService, TestPlanService>();
            //services.AddTransient<IBacklogService, BacklogService>();
        }
    }
}
