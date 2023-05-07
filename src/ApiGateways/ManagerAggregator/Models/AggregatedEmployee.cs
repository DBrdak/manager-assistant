namespace ManagerAggregator.Models
{
    public class AggregatedEmployee
    {
        public EmployeeModel EmployeePersonalData { get; set; }
        public IEnumerable<CompletedShiftModel> CompletedShifts { get; set; }
        public IEnumerable<SalaryModel> Salaries { get; set; }
    }
}
