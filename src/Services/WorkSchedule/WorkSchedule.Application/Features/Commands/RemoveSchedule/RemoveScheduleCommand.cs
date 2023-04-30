using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Commands.RemoveSchedule
{
    public record RemoveScheduleCommand(string MonthName) : ICommand<Result<Unit>>;
}
