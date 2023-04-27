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
        Task<WorkingMonth> GetMonth(string monthName);
    }
}
