using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Month.Commands.PrepareSchedule
{
    public class PrepareScheduleRequestHandler : IRequestHandler<PrepareScheduleRequest, Result<Unit>>
    {
        private readonly IScheduleRepository _repository;

        public PrepareScheduleRequestHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<Unit>> Handle(PrepareScheduleRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.PrepareSchedule(request.WorkingDays);

            return result ? 
                Result<Unit>.Success(Unit.Value) : 
                Result<Unit>.Failure("Can't setup this shedule");
        }
    }
}
