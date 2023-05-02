using MongoDB.Driver;
using Payroll.API.Entities;

namespace Payroll.API.Data
{
    public interface IPayrollContext
    {
        public IMongoCollection<Salary> Salaries { get; set; }
    }
}
