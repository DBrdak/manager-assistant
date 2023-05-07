using ManagerAggregator.Models;

namespace ManagerAggregator.Services;

public interface IAggregatorService
{
    Task<AggregatedEmployee> GetAggregatedEmployeeData(string employeeName);
}