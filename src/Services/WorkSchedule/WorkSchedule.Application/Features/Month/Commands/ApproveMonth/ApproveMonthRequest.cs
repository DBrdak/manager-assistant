using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Month.Commands.ApproveMonth
{
    public class ApproveMonthRequest : IRequest<Result<Unit>>
    {
        public string MonthName { get; set; }

        public ApproveMonthRequest(string monthName)
        {
            MonthName = monthName;
        }
    }
}
