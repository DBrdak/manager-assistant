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
        Task<WorkingMonth?> GetSchedule(string monthName);

        Task<WorkingMonth> GetScheduleForEmployee(string employeeName);

        Task<bool> PrepareSchedule(List<WorkingDay> workingDays);

        Task<bool> ApproveSchedule(string monthName);

        Task<bool> AddAvailability(Shift availability);

        Task<bool> RemoveAvailability(Guid availabilityId);

        Task<bool> UpdateAvailability(Shift availability);
    }
}
