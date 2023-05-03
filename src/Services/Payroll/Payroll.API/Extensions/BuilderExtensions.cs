using Payroll.API.Repositories;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Payroll.API.Data;
using Payroll.API.GrpcServices;
using WorkTimeTracker.Grpc.Protos;

namespace Payroll.API.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection RegisterDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IPayrollContext, PayrollContext>();
            services.AddScoped<IPayrollRepository, PayrollRepository>();
            services.AddScoped<WorkTimeTrackerGrpcService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddGrpcClient<WorkTimeTrackerService.WorkTimeTrackerServiceClient>(o =>
            {
                o.Address = new Uri(config["GrpcSettings:WorkTimeTrackerUrl"] ??
                            throw new InvalidOperationException("WorkTimeTrackerUrl URL not found"));
            });

            return services;
        }
    }
}
