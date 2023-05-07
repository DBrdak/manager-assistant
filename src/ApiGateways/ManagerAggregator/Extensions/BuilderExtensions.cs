using System.Reflection;
using ManagerAggregator.GrpcServices;
using ManagerAggregator.Services;
using WorkTimeTracker.Grpc.Protos;

namespace ManagerAggregator.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddGrpcClient<WorkTimeTrackerService.WorkTimeTrackerServiceClient>(o =>
            {
                o.Address = new Uri(config["GrpcSettings:WorkTimeTrackerUrl"] ??
                                    throw new InvalidOperationException("WorkTimeTrackerUrl URL not found"));
            });
            services.AddHttpClient<IEmployeeService, EmployeeService>(c =>
                c.BaseAddress = new Uri(config["ApiSettings:EmployeeUrl"]));


            services.AddHttpClient<IPayrollService, PayrollService>(c =>
                c.BaseAddress = new Uri(config["ApiSettings:PayrollUrl"]));

            services.AddScoped<IAggregatorService, AggregatorService>();
            services.AddScoped<WorkTimeTrackerGrpcService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
