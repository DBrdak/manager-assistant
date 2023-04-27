
using WorkSchedule.API.Extensions;
using WorkSchedule.Application;
using WorkSchedule.Infrastructure;

namespace Shift.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.InjectApplication();
            builder.Services.InjectInfrastructure(builder.Configuration);

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();
            await app.MigrateDatabase();

            await app.RunAsync();
        }
    }
}