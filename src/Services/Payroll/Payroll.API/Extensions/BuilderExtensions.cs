using Payroll.API.Repositories;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Payroll.API.Data;

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

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
