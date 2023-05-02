using MongoDB.Driver;
using Payroll.API.Entities;

namespace Payroll.API.Data
{
    public class PayrollContext : IPayrollContext
    {
        public IMongoCollection<Salary> Salaries { get; set; }

        public PayrollContext(IConfiguration config)
        {
            var client = new MongoClient(
                config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(
                config.GetValue<string>("DatabaseSettings:DatabaseName"));

            Salaries = database.GetCollection<Salary>(
                config.GetValue<string>("DatabaseSettings:CollectionName"));

            var indexKeysDefinition = Builders<Salary>.IndexKeys.Ascending(x => x.ExpiryDate);
            var indexModel = new CreateIndexModel<Salary>(indexKeysDefinition);
            Salaries.Indexes.CreateOne(indexModel);
            Salaries.SeedData();
        }
    }
}
