using ManagerAggregator.GrpcServices;
using ManagerAggregator.Models;

namespace ManagerAggregator.Services
{
    public class AggregatorService : IAggregatorService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPayrollService _parollService;
        private readonly WorkTimeTrackerGrpcService _workTimeTrackerService;

        public AggregatorService(IEmployeeService employeeService, IPayrollService parollService, WorkTimeTrackerGrpcService workTimeTrackerService)
        {
            _employeeService = employeeService;
            _parollService = parollService;
            _workTimeTrackerService = workTimeTrackerService;
        }

        public async Task<AggregatedEmployee> GetAggregatedEmployeeData(string employeeName)
        {
            var personalData = await _employeeService.GetEmployeePersonalData(employeeName);
            var salaries = await _parollService.GetSalaries(employeeName);
            var completedShifts = await _workTimeTrackerService.GetShifts(employeeName);

            return new AggregatedEmployee
            {
                CompletedShifts = completedShifts,
                EmployeePersonalData = personalData,
                Salaries = salaries
            };
        }
    }
}
