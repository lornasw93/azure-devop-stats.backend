using DevOpsStats.Api.Queries;
using DevOpsStats.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevOpsStats.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            AddQueries(services);
            //AddServices(services);

            return services;
        }

        private static void AddQueries(IServiceCollection services)
        {
            services.AddTransient<IBaseQuery, BaseQuery>();
        }

        private static void AddServices(IServiceCollection services)
        {
        }
    }
}
