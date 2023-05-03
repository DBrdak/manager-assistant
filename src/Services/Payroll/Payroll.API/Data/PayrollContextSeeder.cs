using MongoDB.Driver;
using Payroll.API.Entities;

namespace Payroll.API.Data;

public static class PayrollContextSeeder
{
    public static void SeedData(this IMongoCollection<Salary> salaries)
    {
        if(salaries.CountDocuments(Builders<Salary>.Filter.Empty) > 0)
            return;

        //var seedData = new[]
        //{
        //    new Salary(
        //        "Adam", "adam@test.com",
        //        "555666777", "GB28425160161331926819", "NWBKGB2L",
        //        100, 30,
        //        new DateTime(2023, 1, 10), new DateTime(2023, 1, 20)
        //    ),
        //    new Salary(
        //        "Emily", "emily@test.com",
        //        "777888999", "GB05754220051020123456", "BARCGB22",
        //        0, 27, new DateTime(2023, 1, 10), new DateTime(2023, 1, 20)
        //    ),
        //    new Salary(
        //        "David", "david@test.com",
        //        "111222333", "GB47457200997065202654", "REVOGB21",
        //        500, 41, new DateTime(2023, 1, 10), new DateTime(2023, 1, 20)
        //    ),
        //    new Salary(
        //        "Sarah", "sarah@test.com",
        //        "444555666", "GB14123030964123456789", "LOYDGB21",
        //        50, 23.5m, new DateTime(2023, 1, 10), new DateTime(2023, 1, 20)
        //    )
        //};

        //salaries.InsertMany(seedData);
    }
}