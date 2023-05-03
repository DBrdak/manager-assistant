using MongoDB.Bson;
using MongoDB.Driver;
using Payroll.API.Data;
using Payroll.API.Entities;
using Payroll.API.Entities.Common;
using Payroll.API.GrpcServices;

namespace Payroll.API.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly IPayrollContext _context;
        private readonly WorkTimeTrackerGrpcService _grpcService;

        public PayrollRepository(IPayrollContext context, WorkTimeTrackerGrpcService grpcService)
        {
            _context = context;
            _grpcService = grpcService;
        }

        public async Task<IEnumerable<Salary>> GetAllSalaries() =>
            (await _context.Salaries.Find(s => true).SortBy(s => s.PaymentDate).ToListAsync());

        public async Task<IEnumerable<Salary>> GetSalariesByEmployee(string employeeName) =>
            await _context.Salaries.Find(s => s.EmployeeName == employeeName).SortBy(s => s.PaymentDate).ToListAsync();

        public async Task<bool> PayoffSalary(string salaryId)
        {
            var filter = Builders<Salary>.Filter.Eq("Id", salaryId);
            var update = Builders<Salary>.Update
                .Combine(
                    Builders<Salary>.Update.Set("IsPaid", true),
                    Builders<Salary>.Update.Set("PaymentDate", DateTime.Now)
                );

            var result = await _context.Salaries
                .UpdateOneAsync(filter, update);

            if (!result.IsAcknowledged &&
                !(result.ModifiedCount > 0))
                return false;

            var salary = await _context.Salaries.Find(s => s.Id == salaryId)
                .SingleOrDefaultAsync();

            return await PayoffShifts(salary.EmployeeName, salary.PeriodPaid);
        }

        public async Task AddPendingSalary(Salary salary)
        {
            salary.Hours = await GetHoursFromPeriod(salary.EmployeeName, salary.PeriodPaid);

            await _context.Salaries.InsertOneAsync(salary);
        }

        public async Task<bool> RemovePendingSalary(string salaryId)
        {
            var result = await _context.Salaries
                .DeleteOneAsync(s => s.Id == salaryId
                                && s.IsPaid == false);

            return result.DeletedCount > 0 && 
                   result.IsAcknowledged;
        }

        public async Task<bool> SendEmail()
        {
            throw new NotImplementedException();
        }

        private async Task<bool> PayoffShifts(string employeeName, Period period)
        {
            var dates = GetDatesFromPeriod(period);

            var shifts = await _grpcService.GetShifts(employeeName, dates);

            var result = await _grpcService.SetShiftsAsPaid(shifts.Select(s => s.Id));

            return result;
        }

        private IEnumerable<DateTime> GetDatesFromPeriod(Period period)
        {
            var result = new List<DateTime>();

            for (DateTime i = period.From; i <= period.To; i = i.AddDays(1))
            {
                result.Add(i);
            }

            return result;
        }

        private async Task<decimal> GetHoursFromPeriod(string employeeName, Period period)
        {
            var dates = GetDatesFromPeriod(period);

            var shifts = await _grpcService.GetShifts(employeeName, dates);

            if (!shifts.Any())
                return 0;

                return (decimal)shifts.Select(s => s.NumberOfHours).Sum();
        }
    }
}
