using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using WorkTimeTracker.Grpc.Protos;
using WorkTimeTracker.Grpc.Repositories;

namespace WorkTimeTracker.Grpc.Services
{
    public class WorkTimeTrackerService : Protos.WorkTimeTrackerService.WorkTimeTrackerServiceBase
    {
        private readonly ILogger<WorkTimeTrackerService> _logger;
        private readonly IMapper _mapper;
        private readonly IWorkTimeTrackerRepository _repository;

        public WorkTimeTrackerService(ILogger<WorkTimeTrackerService> logger, IMapper mapper, IWorkTimeTrackerRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task<GetCompletedShiftsResponse> GetCompletedShiftsByEmployee(GetCompletedShiftsRequest request, ServerCallContext context)
        {
            var completedShifts = await _repository.GetByEmployee(request.EmployeeName);
            
            return _mapper.Map<GetCompletedShiftsResponse>(completedShifts);
        }

        //public override Task<Empty> AddCompletedShift(AddCompletedShiftRequest request, ServerCallContext context)
        //{

        //}
    }
}
