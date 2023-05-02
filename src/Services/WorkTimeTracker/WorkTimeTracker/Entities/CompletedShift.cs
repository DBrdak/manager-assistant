using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ThirdParty.BouncyCastle.Utilities.IO.Pem;

namespace WorkTimeTracker.API.Entities
{
    public class CompletedShift
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        public string EmployeeName { get; set; }
        [BsonRequired]
        public DateTime ShiftStart { get; set; }
        [BsonRequired]
        public DateTime ShiftEnd { get; set; }

        public bool IsPaid { get; set; }
        public DateTime ExpiryDate { get; set; }
        public TimeSpan NumberOfHours => ShiftEnd - ShiftStart;

        [JsonConstructor]
        public CompletedShift(string employeeName, DateTime shiftStart, DateTime shiftEnd)
        {
            EmployeeName = employeeName;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            IsPaid = false;
            ExpiryDate = DateTime.Now.AddYears(1);
        }
    }
}
