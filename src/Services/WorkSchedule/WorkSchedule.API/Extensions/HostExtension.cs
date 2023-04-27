using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shift.API;
using WorkSchedule.API.Controllers;
using WorkSchedule.Infrastructure.Persistence;

namespace WorkSchedule.API.Extensions
{
    public static class HostExtenstion
    {
        public static async Task<IHost> MigrateDatabase(this IHost app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ScheduleContext>();
                await context.Database.MigrateAsync();
                context.Seed();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex.Message, "Error occured during migration");
            }

            return app;
        }
    }
}
