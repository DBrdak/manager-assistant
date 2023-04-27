using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Employee.API.Data
{
    public class EmployeeContext : IEmployeeContext
    {
        public IMongoCollection<Entities.Employee> Employees { get; }

        public EmployeeContext(IConfiguration config)
        {
            var client = new MongoClient(
                config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(
                config.GetValue<string>("DatabaseSettings:DatabaseName"));

            Employees = database.GetCollection<Entities.Employee>(
                config.GetValue<string>("DatabaseSettings:CollectionName"));
            Employees.SeedData();
        }
    }
}
