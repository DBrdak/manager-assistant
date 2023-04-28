using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Features.Commands.RemoveAvailability;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Month.Commands.RemoveAvailability
{
    public class RemoveAvailabilityCommandHandler : ICommandHandler<RemoveAvailabilityCommand, Result<Unit>>
    {
        private readonly IScheduleRepository _repository;

        public RemoveAvailabilityCommandHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<Unit>> Handle(RemoveAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.RemoveAvailability(request.AvailabilityId);

            return result ?
                Result<Unit>.Success(Unit.Value) :
                Result<Unit>.Failure("Can't delete specified shift");
        }
    }
}
