using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Month.Commands.AddAvailability
{
    public class AddAvailabilityCommandHandler : ICommandHandler<AddAvailabilityCommand, Result<Unit>>
    {
        private readonly IScheduleRepository _repository;

        public AddAvailabilityCommandHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Unit>> Handle(AddAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.AddAvailability(request.Availability);

            return result ? 
                Result<Unit>.Success(Unit.Value) : 
                Result<Unit>.Failure("Problem while adding availability");
        }
    }
}
