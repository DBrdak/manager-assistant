using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;

namespace WorkSchedule.Application.Features.Month.Commands.ApproveMonth
{
    public class ApproveScheduleCommandHandler : ICommandHandler<ApproveScheduleCommand, Result<Unit>>
    {
        private readonly IScheduleRepository _repository;

        public ApproveScheduleCommandHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Unit>> Handle(ApproveScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.ApproveSchedule(request.MonthName);

            return result ? 
                Result<Unit>.Success(Unit.Value) :
                Result<Unit>.Failure("You can't approve this month");
        }
    }
}
