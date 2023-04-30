using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Extensions;
using WorkSchedule.Application.Features.Month.Commands.AddAvailability;
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

        public async Task<WorkingMonth?> GetSchedule(string monthName, string employeeName)
        {
            var month = await _context.Set<WorkingMonth>()
                .Include(wm => wm.WorkingDays.OrderBy(wd => wd.Date))
                .ThenInclude(wd => wd.Shifts.OrderBy(s => s.StartHour))
                .AsNoTracking()
                .FirstOrDefaultAsync(wm => wm.MonthName == monthName
                                           && (wm.MonthStartDate.Year == DateTime.Now.Year
                                               || wm.MonthEndDate.Year == DateTime.Now.Year));

            if(employeeName is not null && employeeName is not "") 
                month.WorkingDays = month.WorkingDays
                .Where(wd => wd.Shifts.Any(s => s.EmployeeName == employeeName));

            return month;
        }

        public async Task<bool> PrepareSchedule(WorkingMonth schedule)
        {
            var copy = await _context.Set<WorkingMonth>()
                .FirstOrDefaultAsync(wm => wm.MonthName == schedule.MonthName ||
                                           wm.MonthStartDate == schedule.MonthStartDate ||
                                           wm.MonthEndDate == schedule.MonthEndDate);

            if (copy is not null)
                return false;

            await _context.AddAsync(schedule);

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ApproveSchedule(string monthName)
        {
            var schedule = await _context.Set<WorkingMonth>()
                .FirstOrDefaultAsync(wm => wm.MonthName == monthName);

            if(schedule is null)
                return false;

            schedule.IsApproved = true;

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> AddAvailability(AddAvailabilityCommand command)
        {
            var workingDay = await _context.Set<WorkingDay>()
                .FirstOrDefaultAsync(wd => wd.Date.Day == command.WorkingDay.Day
                                    && wd.Date.Month == command.WorkingDay.Month);
            
            if (workingDay is null)
                return false;
            
            workingDay.Shifts = workingDay.Shifts.Append(command.Availability).ToList();
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> RemoveAvailability(Guid availabilityId)
        {
            var availability = await _context.Set<Shift>()
                .FindAsync(availabilityId);

            if (availability is null) 
                return false;

            _context.Remove(availability);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateShift(Shift shift)
        {
            var shiftToUpdate = await _context.Set<Shift>()
                .FindAsync(shift.Id);

            if(shiftToUpdate is null)
                return false;

            shiftToUpdate.Replace(shift);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> RemoveSchedule(string monthName)
        {
            var schedule = await _context.Set<WorkingMonth>()
                .FirstOrDefaultAsync(wm => wm.MonthName == monthName);

            if (schedule is null)
                return false;

            _context.Remove(schedule);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> SendEmailToEmployees()
        {
            throw new NotImplementedException();
        }

    }
}
