using Employee.API.Data;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace Employee.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IEmployeeContext _context;

        public EmployeeRepository(IEmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Employee>> GetEmployees()
        {
            return await _context.Employees
                .Find(e => true)
                .ToListAsync();
        }

        public async Task<bool> HireEmployee(Entities.Employee newEmployee)
        {
            var check = await _context.Employees
                .Find(e => e.UniqueName == newEmployee.UniqueName).AnyAsync();

            if(check)
                return false;

            await _context.Employees.InsertOneAsync(newEmployee);

            check = await _context.Employees
                .Find(e => e.UniqueName == newEmployee.UniqueName).AnyAsync();

            return check;
        }

        public async Task<bool> UpdateEmployeeData(Entities.Employee employee)
        {
            var result = await _context.Employees
                .ReplaceOneAsync(e => e.Id == employee.Id, employee);

            return result.IsAcknowledged &&
                   result.ModifiedCount > 0;
        }

        public async Task<bool> FireEmployee(string employeeId)
        {
            await _context.Employees
                .FindOneAndDeleteAsync(e => e.Id == employeeId);

            var result = await _context.Employees
                .Find(e => e.Id == employeeId).AnyAsync();

            return !result;
        }
    }
}
