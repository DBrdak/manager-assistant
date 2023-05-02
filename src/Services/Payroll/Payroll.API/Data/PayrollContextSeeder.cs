using MongoDB.Driver;
using Payroll.API.Entities;

namespace Payroll.API.Data;

public static class PayrollContextSeeder
{
    public static void SeedData(this IMongoCollection<Salary> salaries)
    {
        if(salaries.CountDocuments(Builders<Salary>.Filter.Empty) > 0)
            return;

        var seedData = new[]
        {
            new Salary(
                "Adam", "adam@test.com",
                "555666777", "GB28425160161331926819", "NWBKGB2L",
                80, 100, 30,
                DateTime.UtcNow.Date.AddMonths(-1), DateTime.UtcNow.Date.AddMonths(-1).AddDays(15)
            ),
            new Salary(
                "Emily", "emily@test.com",
                "777888999", "GB05754220051020123456", "BARCGB22",
                60, 0, 27, DateTime.UtcNow.Date.AddMonths(-2), DateTime.UtcNow.Date.AddMonths(-2).AddDays(15)
            ),
            new Salary(
                "David", "david@test.com",
                "111222333", "GB47457200997065202654", "REVOGB21",
                50, 500, 41, DateTime.UtcNow.Date.AddMonths(-2), DateTime.UtcNow.Date.AddMonths(-2).AddDays(15)
            ),
            new Salary(
                "Sarah", "sarah@test.com",
                "444555666", "GB14123030964123456789", "LOYDGB21",
                120, 50, 23.5m, DateTime.UtcNow.Date.AddMonths(-2), DateTime.UtcNow.Date.AddMonths(-2).AddDays(15)
            )
        };

        salaries.InsertMany(seedData);
    }
}