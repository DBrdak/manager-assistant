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

        public async Task<WorkingMonth?> GetSchedule(string monthName) =>
            await _context.Set<WorkingMonth>()
                .Include(wm => wm.WorkingDays.OrderBy(wd => wd.Date))
                .ThenInclude(wd => wd.Shifts.OrderBy(s => int.Parse(s.StartHour)))
                .AsNoTracking()
                .FirstOrDefaultAsync(wm => wm.MonthName == monthName
                                           && wm.MonthStartDate.Year == DateTime.Now.Year);

        public async Task<WorkingMonth> GetScheduleForEmployee(string employeeName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PrepareSchedule(List<WorkingDay> workingDays)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ApproveSchedule(string monthName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAvailability(Shift availability)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAvailability(Guid availabilityId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAvailability(Shift availability)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostSchdule(string monthName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetAvailability(Shift availability)
        {
            throw new NotImplementedException();
        }

    }
}
