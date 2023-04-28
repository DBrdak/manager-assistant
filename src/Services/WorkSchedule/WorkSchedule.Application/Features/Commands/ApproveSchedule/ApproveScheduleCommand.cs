using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Month.Commands.ApproveMonth
{
    public sealed record ApproveScheduleCommand(string MonthName) : ICommand<Result<Unit>>;
}
