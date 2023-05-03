using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Payroll.API.Entities.Common;
using System.Numerics;
using System.Text.Json.Serialization;
using ThirdParty.BouncyCastle.Utilities.IO.Pem;

namespace Payroll.API.Entities
{
    public class Salary
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string EmployeeName { get; set; }
        public TransferData EmployeeFinancialData { get; set; }
        public decimal TotalSalary => Wage * Hours + Additions;
        public decimal Hours { get; set; }
        public decimal Additions { get; set; }
        public decimal Wage { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Period PeriodPaid { get; set; }
        public bool IsPaid { get; set; }
        public DateTime ExpiryDate { get; set; }

        
        public Salary(string employeeName, string email, string phone, 
            string iban, string swift, decimal additions, 
            decimal wage, DateTime paidFrom, DateTime paidTo)
        {
            EmployeeName = employeeName;
            EmployeeFinancialData = new TransferData(email, phone, iban, swift);
            Hours = 0;
            Additions = additions;
            Wage = wage;
            PaymentDate = null;
            PeriodPaid = new Period(paidFrom, paidTo);
            IsPaid = false;
            ExpiryDate = DateTime.UtcNow.AddYears(1);
        }

        [JsonConstructor]
        public Salary(string employeeName, TransferData employeeFinancialData,
            decimal additions, decimal wage, Period periodPaid)
        {
            EmployeeName = employeeName;
            EmployeeFinancialData = employeeFinancialData;
            Hours = 0;
            Additions = additions;
            Wage = wage;
            PaymentDate = null;
            PeriodPaid = periodPaid;
            IsPaid = false;
            ExpiryDate = DateTime.UtcNow.AddYears(1);
        }
    }
}
