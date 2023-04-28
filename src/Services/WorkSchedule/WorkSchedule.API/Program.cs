
using WorkSchedule.API.Extensions;
using WorkSchedule.API.Middlewares;
using WorkSchedule.Application;
using WorkSchedule.Infrastructure;

namespace Shift.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.InjectDependency(builder.Configuration);

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            await app.MigrateDatabase();

            await app.RunAsync();
        }
    }
}