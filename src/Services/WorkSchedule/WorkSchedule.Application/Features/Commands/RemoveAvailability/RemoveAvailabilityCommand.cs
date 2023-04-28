using MediatR;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Commands.RemoveAvailability
{
    public record RemoveAvailabilityCommand(Guid AvailabilityId) : ICommand<Result<Unit>>;
}
