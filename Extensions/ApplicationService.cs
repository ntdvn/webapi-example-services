using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapi_example_services.Services;

namespace webapi_example_services.Extensions
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICMCCrawlerServices, CMCCrawlerServices>();
            return services;
        }
    }
}