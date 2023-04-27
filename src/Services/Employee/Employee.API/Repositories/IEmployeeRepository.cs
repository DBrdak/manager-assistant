using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Entities.Employee>> GetEmployees();
        Task<bool> HireEmployee(Entities.Employee newEmployee);
        Task<bool> UpdateEmployeeData(Entities.Employee employee);
        Task<bool> FireEmployee(string employeeId);
    }
}
