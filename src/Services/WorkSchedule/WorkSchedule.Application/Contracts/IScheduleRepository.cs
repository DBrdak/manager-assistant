using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Contracts
{
    public interface IScheduleRepository
    {
        Task<WorkingMonth?> GetSchedule(string monthName, string employeeName);

        Task<bool> PrepareSchedule(WorkingMonth schedule);

        Task<bool> ApproveSchedule(string monthName);

        Task<bool> AddAvailability(Shift availability);

        Task<bool> RemoveAvailability(Guid availabilityId);

        Task<bool> UpdateShift(Shift shift);

        Task<bool> RemoveSchedule(Guid scheduleId);

        Task<bool> SendEmailToEmployees();
    }
}
