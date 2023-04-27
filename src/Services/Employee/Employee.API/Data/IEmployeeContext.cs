using MongoDB.Driver;

namespace Employee.API.Data
{
    public interface IEmployeeContext
    {
        IMongoCollection<Entities.Employee> Employees { get; }
    }
}
