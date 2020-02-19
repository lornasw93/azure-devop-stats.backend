using DevOpsStats.Api.Queries;
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
            services.AddTransient<IBaseQuery, BaseQuery>();
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
