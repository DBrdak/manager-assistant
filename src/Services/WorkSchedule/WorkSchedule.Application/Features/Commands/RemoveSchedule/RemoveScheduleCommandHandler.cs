using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Commands.RemoveSchedule
{
    public class RemoveScheduleCommandHandler : ICommandHandler<RemoveScheduleCommand, Result<Unit>>
    {
        private readonly IScheduleRepository _repository;

        public RemoveScheduleCommandHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<Unit>> Handle(RemoveScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.RemoveSchedule(request.MonthName);

            return result ?
                    Result<Unit>.Success(Unit.Value) :
                    Result<Unit>.Failure("Can't remove this schedule");
        }
    }
}
