using System.Globalization;
using WorkTimeTracker.Grpc.Protos;

namespace Payroll.API.GrpcServices
{
    public class WorkTimeTrackerGrpcService
    {
        private readonly WorkTimeTrackerService.WorkTimeTrackerServiceClient _grpcClient;

        public WorkTimeTrackerGrpcService(WorkTimeTrackerService.WorkTimeTrackerServiceClient grpcClient)
        {
            _grpcClient = grpcClient;
        }

        public async Task<IEnumerable<CompletedShiftGetModel>> GetShifts(string employeeName, IEnumerable<DateTime> shiftsDate)
        {
            var request = new GetCompletedShiftsRequest() { EmployeeName = employeeName };
            var response = await _grpcClient.GetCompletedShiftsByEmployeeAsync(request);

            var shifts = new List<CompletedShiftGetModel>();

            foreach (var shiftDate in shiftsDate)
            {
                var a = shiftDate.ToString(CultureInfo.InvariantCulture);
                var b = response.CompletedShifts.Select(s => s.StartTime);

                var shift = response.CompletedShifts.FirstOrDefault
                    (cs => parseToDateOnlyString(cs.StartTime) == parseToDateOnlyString(shiftDate.ToString(CultureInfo.InvariantCulture)) ||
                    parseToDateOnlyString(cs.EndTime) == parseToDateOnlyString(shiftDate.ToString(CultureInfo.InvariantCulture)));

                if(shift is not null) shifts.Add(shift);
            }

            shifts = shifts.Distinct().ToList();

            return shifts;
        }

        public async Task<bool> SetShiftsAsPaid(IEnumerable<string> shiftsId)
        {
            var result = new List<SetAsPaidResponse>();
            foreach (var shiftId in shiftsId)
            {
                var request = new SetAsPaidRequest() { CompletedShiftId = shiftId };
                result.Add(await _grpcClient.SetAsPaidAsync(request));
            }

            return result.All(r => r.Result);
        }

        private Func<string, string> parseToDateOnlyString = x => x.Split(' ')[0];
    }
}
