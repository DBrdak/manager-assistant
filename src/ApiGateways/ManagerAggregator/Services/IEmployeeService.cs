using ManagerAggregator.Models;

namespace ManagerAggregator.Services;

public interface IEmployeeService
{
    Task<EmployeeModel> GetEmployeePersonalData(string employeeName);
}