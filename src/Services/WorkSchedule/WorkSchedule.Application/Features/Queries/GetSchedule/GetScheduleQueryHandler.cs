using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WorkSchedule.Application.Contracts;
using WorkSchedule.Application.Core.Interfaces;
using WorkSchedule.Application.Models;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Features.Month.Queries.GetMonth
{
    public class GetScheduleQueryHandler : ICommandHandler<GetScheduleQuery, Result<WorkingMonth>>
    {
        private readonly IScheduleRepository _repository;

        public GetScheduleQueryHandler(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<WorkingMonth>> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
        {
            var workingMonth = await _repository.GetSchedule(request.MonthName, request.EmployeeName);

            return workingMonth is null ? 
                Result<WorkingMonth>.Failure("No schedule available") : 
                Result<WorkingMonth>.Success(workingMonth);
        }
    }
}
