using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using WorkTimeTracker.Grpc.Data;
using WorkTimeTracker.Grpc.Repositories;

namespace WorkTimeTracker.Grpc.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection RegisterDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IWorkTimeTrackerContext, WorkTimeTrackerContext>();
            services.AddScoped<IWorkTimeTrackerRepository, WorkTimeTrackerRepository>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
