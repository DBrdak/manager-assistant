using WorkTimeTracker.API.Data;
using WorkTimeTracker.API.Repositories;

namespace WorkTimeTracker.API.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection RegisterDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IWorkTimeTrackerContext, WorkTimeTrackerContext>();
            services.AddScoped<IWorkTimeTrackerRepository, WorkTimeTrackerRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
