using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Features.Month.Commands.UpdateAvailability;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Commands.UpdateShift
{
    public class UpdateShiftCommandHandler : ICommandHandler<UpdateShiftCommand, Result<Unit>>
    {
        private readonly IScheduleRepository _repository;

        public UpdateShiftCommandHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<Unit>> Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.UpdateShift(request.Shift);

            return result ?
                Result<Unit>.Success(Unit.Value) :
                Result<Unit>.Failure("Can't update specified shift");
        }
    }
}
