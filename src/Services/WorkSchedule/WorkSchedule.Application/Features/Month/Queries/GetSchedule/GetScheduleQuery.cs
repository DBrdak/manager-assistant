using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Models;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Features.Month.Queries.GetMonth
{
    public class GetScheduleQuery : IRequest<Result<WorkingMonth>>
    {
        public string Month { get; set; }

        public GetScheduleQuery(string month)
        {
            Month = month;
        }
    }
}
