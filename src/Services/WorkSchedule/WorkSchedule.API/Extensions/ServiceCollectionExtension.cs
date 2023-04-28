using WorkSchedule.API.Middlewares;
using WorkSchedule.Application;
using WorkSchedule.Infrastructure;

namespace WorkSchedule.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InjectDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            services.InjectApplication();
            services.InjectInfrastructure(config);

            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}
