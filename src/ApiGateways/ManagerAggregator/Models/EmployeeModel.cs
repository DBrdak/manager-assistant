using System.Text.Json.Serialization;

namespace ManagerAggregator.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UniqueName { get; set; }
        
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }
        
        public string IBAN { get; set; }
        public string SWIFT { get; set; }
    }
}
