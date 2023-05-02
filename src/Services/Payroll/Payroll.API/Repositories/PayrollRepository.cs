using MongoDB.Bson;
using MongoDB.Driver;
using Payroll.API.Data;
using Payroll.API.Entities;

namespace Payroll.API.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly IPayrollContext _context;

        public PayrollRepository(IPayrollContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salary>> GetAllSalaries() =>
            (await _context.Salaries.Find(s => true).SortBy(s => s.PaymentDate).ToListAsync());

        public async Task<IEnumerable<Salary>> GetSalariesByEmployee(string employeeName) =>
            await _context.Salaries.Find(s => s.EmployeeName == employeeName).SortBy(s => s.PaymentDate).ToListAsync();

        async Task<bool> IPayrollRepository.PayoffSalary(string salaryId)
        {
            var filter = Builders<Salary>.Filter.Eq("Id", salaryId);
            var update = Builders<Salary>.Update
                .Combine(
                    Builders<Salary>.Update.Set("IsPaid", true),
                    Builders<Salary>.Update.Set("PaymentDate", DateTime.Now)
                );

            var result = await _context.Salaries
                .UpdateOneAsync(filter, update);

            return result.IsAcknowledged &&
                   result.ModifiedCount > 0;
        }

        public async Task AddPendingSalary(Salary salary) =>
            await _context.Salaries.InsertOneAsync(salary);

        public async Task<bool> RemovePendingSalary(string salaryId)
        {
            var result = await _context.Salaries
                .DeleteOneAsync(s => s.Id == salaryId
                                && s.IsPaid == false);

            return result.DeletedCount > 0 && 
                   result.IsAcknowledged;
        }
    }
}
