
using Payroll.API.Extensions;
using Payroll.API.Middlewares;

namespace Payroll.API
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

            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();
            app.UseMiddleware<ExceptionMiddleware>();

            app.Run();
        }
    }
}