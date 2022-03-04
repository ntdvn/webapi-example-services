using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace webapi_example_services.Extensions
{
    public static class JsonServiceExtension
    {
        public static IServiceCollection AddJsonService(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddControllers()
               .AddJsonOptions(options =>
               {

                   options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                   options.JsonSerializerOptions.IgnoreNullValues = true;

               })
               .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    // options.SerializerSettings.Converters.Add(new DateTimeConverter());
                })
            ;

            return services;
        }
    }
}