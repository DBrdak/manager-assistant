using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Application.Features.Month.Commands.AddAvailability;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Contracts
{
    public interface IScheduleRepository
    {
        Task<WorkingMonth?> GetSchedule(string monthName, string employeeName);

        Task<bool> PrepareSchedule(WorkingMonth schedule);

        Task<bool> ApproveSchedule(string monthName);

        Task<bool> AddAvailability(AddAvailabilityCommand command);

        Task<bool> RemoveAvailability(Guid availabilityId);

        Task<bool> UpdateShift(Shift shift);

        Task<bool> RemoveSchedule(string monthName);

        Task<bool> SendEmailToEmployees();
    }
}
