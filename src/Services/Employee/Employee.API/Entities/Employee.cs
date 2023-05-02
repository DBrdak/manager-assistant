using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Employee.API.Entities
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        // Personal Info
        [BsonRequired]
        public string FirstName { get; set; }
        [BsonRequired]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [BsonRequired]
        public string UniqueName { get; set; }

        // Address Info
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }

        // Financial Info
        [BsonRequired]
        public string IBAN { get; set; }
        public string SWIFT { get; set; }

        public Employee(string firstName, string lastName, string email, string phone, string uniqueName, string city, string street, string postalCode, string buildingNumber, string iban, string swift)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            UniqueName = uniqueName;
            City = city;
            Street = street;
            PostalCode = postalCode;
            BuildingNumber = buildingNumber;
            IBAN = iban;
            SWIFT = swift;
        }
    }
}
