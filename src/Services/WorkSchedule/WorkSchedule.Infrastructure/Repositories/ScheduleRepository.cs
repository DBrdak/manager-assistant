using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Domain.Entities;
using WorkSchedule.Infrastructure.Persistence;

namespace WorkSchedule.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext _context;

        public ScheduleRepository(ScheduleContext context)
        {
            _context = context;
        }

        public async Task<WorkingMonth> GetMonth(string monthName) =>
            await _context.Set<WorkingMonth>()
                .Include(wm => wm.WorkingDays)
                .ThenInclude(wd => wd.Shifts)
                .AsNoTracking()
                .FirstOrDefaultAsync(wm => wm.MonthName == monthName 
                                           && wm.MonthStartDate.Year == DateTime.Now.Year);
    }
}
