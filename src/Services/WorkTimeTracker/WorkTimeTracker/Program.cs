
using WorkTimeTracker.API.Extensions;
using WorkTimeTracker.API.Middlewares;

namespace WorkTimeTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.RegisterDependency(builder.Configuration);

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}