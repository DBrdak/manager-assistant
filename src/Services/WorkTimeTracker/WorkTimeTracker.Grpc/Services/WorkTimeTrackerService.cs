using Amazon.Runtime.Internal;
using AutoMapper;
using FluentValidation;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WorkTimeTracker.Grpc.Entities;
using WorkTimeTracker.Grpc.Protos;
using WorkTimeTracker.Grpc.Repositories;
using WorkTimeTracker.Grpc.Validators;

namespace WorkTimeTracker.Grpc.Services
{
    public class WorkTimeTrackerService : Protos.WorkTimeTrackerService.WorkTimeTrackerServiceBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkTimeTrackerRepository _repository;

        public WorkTimeTrackerService(IMapper mapper, IWorkTimeTrackerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task<GetCompletedShiftsResponse> GetCompletedShiftsByEmployee(GetCompletedShiftsRequest request, ServerCallContext context)
        {
            var completedShifts = await _repository.GetByEmployee(request.EmployeeName);
            var completedShiftModels = _mapper.Map<RepeatedField<CompletedShiftGetModel>>(completedShifts);

            var repeatedModels = new RepeatedField<CompletedShiftGetModel>();
            repeatedModels.AddRange(completedShiftModels);

            var result = _mapper.Map<GetCompletedShiftsResponse>(repeatedModels);

            return result;
        }

        public override async Task<AddCompletedShiftResponse> AddCompletedShift(AddCompletedShiftRequest request, ServerCallContext context)
        {
            var preValidator = new CompletedShiftPostModelValidator();
            var result = (await preValidator.ValidateAsync(request.CompletedShift)).IsValid;

            if (!result)
                return new() { Result = false };

            var completedShift = _mapper.Map<CompletedShift>(request.CompletedShift);

            var validator = new CompletedShiftValidator();
            result = (await validator.ValidateAsync(completedShift)).IsValid;

            if (!result)
                return new() { Result = false };

            await _repository.AddCompletedShift(completedShift);

            return new() { Result = true };
        }

        public override async Task<SetAsPaidResponse> SetAsPaid(SetAsPaidRequest request, ServerCallContext context) =>
            new()
            {
                Result = await _repository.SetAsPaid(request.CompletedShiftId)
            };

        public override async Task<RemoveCompletedShiftResponse> RemoveCompletedShift(RemoveCompletedShiftRequest request,
            ServerCallContext context) =>
            new()
            {
                Result = await _repository.RemoveCompletedShift(request.CompletedShiftId)
            };
    }
}
