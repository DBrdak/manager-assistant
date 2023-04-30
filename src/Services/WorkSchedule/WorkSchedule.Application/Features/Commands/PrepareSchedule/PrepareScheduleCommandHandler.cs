using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Features.Commands.PrepareSchedule;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Month.Commands.PrepareSchedule
{
    public class PrepareScheduleCommandHandler : ICommandHandler<PrepareScheduleCommand, Result<Unit>>
    {
        private readonly IScheduleRepository _repository;

        public PrepareScheduleCommandHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<Unit>> Handle(PrepareScheduleCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.PrepareSchedule(command.Schedule);

            return result ? 
                Result<Unit>.Success(Unit.Value) :
                Result<Unit>.Failure("Can't setup this schedule");
        }
    }
}
