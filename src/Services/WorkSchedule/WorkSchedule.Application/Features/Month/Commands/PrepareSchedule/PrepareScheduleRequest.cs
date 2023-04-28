using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Models;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Features.Month.Commands.PrepareSchedule
{
    public class PrepareScheduleRequest : IRequest<Result<Unit>>
    {
        public List<WorkingDay> WorkingDays { get; set; }

        public PrepareScheduleRequest(List<WorkingDay> workingDays)
        {
            WorkingDays = workingDays;
        }
    }
}
