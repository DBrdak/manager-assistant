using Payroll.API.Entities;
using System.Collections.Generic;

namespace Payroll.API.Repositories
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<Salary>> GetAllSalaries();
        Task<IEnumerable<Salary>> GetSalariesByEmployee(string employeeName);
        Task<bool> PayoffSalary(string salaryId);
        Task AddPendingSalary(Salary salary);
        Task<bool> RemovePendingSalary(string salaryId);
        Task<bool> SendEmail(); // Configurantion needed
    }
}
