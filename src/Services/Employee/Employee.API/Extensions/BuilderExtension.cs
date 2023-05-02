using Employee.API.Data;
using Employee.API.Middlewares;
using Employee.API.Repositories;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Employee.API.Extensions
{
    public static class BuilderExtension
    {
        public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IEmployeeContext, EmployeeContext>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
