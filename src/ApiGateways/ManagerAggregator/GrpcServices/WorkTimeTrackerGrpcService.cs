using System.Globalization;
using AutoMapper;
using ManagerAggregator.Models;
using WorkTimeTracker.Grpc.Protos;

namespace ManagerAggregator.GrpcServices
{
    public class WorkTimeTrackerGrpcService
    {
        private readonly WorkTimeTrackerService.WorkTimeTrackerServiceClient _grpcClient;
        private readonly IMapper _mapper;

        public WorkTimeTrackerGrpcService(WorkTimeTrackerService.WorkTimeTrackerServiceClient grpcClient, IMapper mapper)
        {
            _grpcClient = grpcClient;
            _mapper = mapper;
        }

        public async Task<List<CompletedShiftModel>> GetShifts(string employeeName)
        {
            var request = new GetCompletedShiftsRequest() { EmployeeName = employeeName };
            var response = await _grpcClient.GetCompletedShiftsByEmployeeAsync(request);

            var shifts = new List<CompletedShiftGetModel>();
            shifts.AddRange(response.CompletedShifts);

            var result = _mapper.Map<List<CompletedShiftModel>>(shifts);

            return result.OrderBy(s => s.ShiftStart).ToList();
        }
    }
}
