using WorkTimeTracker.Grpc.Extensions;
using WorkTimeTracker.Grpc.Middlewares;
using WorkTimeTracker.Grpc.Services;

namespace WorkTimeTracker.Grpc
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.RegisterDependency(builder.Configuration);

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<WorkTimeTrackerService>();
            });

            await app.RunAsync();
        }
    }
}