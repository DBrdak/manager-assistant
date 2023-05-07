using ManagerAggregator.Models;

namespace ManagerAggregator.Services;

public interface IPayrollService
{
    Task<IEnumerable<SalaryModel>> GetSalaries(string employeeName);
}