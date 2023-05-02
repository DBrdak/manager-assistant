using System.Xml.Serialization;
using MongoDB.Driver;

namespace Employee.API.Data
{
    public static class EmployeeContextSeed
    {
        public static void SeedData(this IMongoCollection<Entities.Employee> employeeDb)
        {
            if (!employeeDb.Find(e => true).Any())
                employeeDb.InsertMany(CreateSampleData());
        }

        private static IEnumerable<Entities.Employee> CreateSampleData()
            => new List<Entities.Employee>
            {
                new("Adam", "Smith", "adam@test.com", "555666777", "Adam", "London", "Rose st.", "SE10 9DL", "44/14", "GB28425160161331926819", "NWBKGB2L"),
                new("Emily", "Jones", "emily@test.com", "777888999", "Emily", "London", "Churchill Rd.", "SW19 6LH", "32/10", "GB05754220051020123456", "BARCGB22"),
                new("David", "Lee", "david@test.com", "111222333", "David", "London", "High St.", "W8 4LL", "12/3", "GB47457200997065202654", "REVOGB21"),
                new("Sarah", "Brown", "sarah@test.com", "444555666", "Sarah", "London", "Baker St.", "NW1 6XE", "8/5", "GB14123030964123456789", "LOYDGB21"),
                new("Michael", "Wong", "michael@test.com", "999888777", "Michael", "London", "Park St.", "SE1 9EQ", "15/2", "GB42HSBC40419965432156", "HSBCGB22"),
                new("Karen", "Taylor", "karen@test.com", "333444555", "Karen", "London", "Smith St.", "E1W 1AW", "21/1", "GB26122154012012345678", "NWBKGB2L"),
                new("Tom", "White", "tom@test.com", "222333444", "Tom", "London", "Jermyn St.", "SW1Y 4UJ", "7/3", "GB15120920152512345678", "BARCGB22"),
                new("Olivia", "Davis", "olivia@test.com", "666777888", "Olivia", "London", "Kensington Rd.", "W8 4LA", "54/10", "GB35654300669012345678", "REVOGB21"),
                new("Lucas", "Wilson", "lucas@test.com", "888999000", "Lucas", "London", "Ludgate Hill", "EC4M 7JN", "6/5", "GB52234520345678123456", "LOYDGB21")
            };
    }
}
