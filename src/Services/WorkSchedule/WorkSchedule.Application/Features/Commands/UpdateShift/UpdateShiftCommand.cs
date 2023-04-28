using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Features.Month.Commands.UpdateAvailability
{
    public record UpdateShiftCommand(Shift Shift) : ICommand<Result<Unit>>;
}
