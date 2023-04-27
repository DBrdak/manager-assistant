using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Infrastructure.Persistence;
using WorkSchedule.Infrastructure.Repositories;

namespace WorkSchedule.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection InjectInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ScheduleContext>(opt =>
                opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IScheduleRepository), typeof(ScheduleRepository));

            return services;
        }
    }
}
