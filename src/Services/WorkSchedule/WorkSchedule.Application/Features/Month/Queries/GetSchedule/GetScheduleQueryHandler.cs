using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Models;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Features.Month.Queries.GetMonth
{
    public class GetScheduleQueryHandler : IRequestHandler<GetMonthQuery, Result<WorkingMonth>>
    {
        private readonly IScheduleRepository _repository;

        public GetScheduleQueryHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<WorkingMonth>> Handle(GetMonthQuery request, CancellationToken cancellationToken)
        {
            var workingMonth = await _repository
                .GetSchedule(request.Month);

            if (workingMonth == null)
                return Result<WorkingMonth>.Failure("No schedule for this month");

            return Result<WorkingMonth>.Success(workingMonth);
        }
    }
}
