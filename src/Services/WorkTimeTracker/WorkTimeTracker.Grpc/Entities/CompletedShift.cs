using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkTimeTracker.Grpc.Entities
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
        [JsonIgnore]
        public DateTime ExpiryDate { get; set; }
        [BsonIgnore]
        [JsonIgnore]
        private TimeSpan numberOfHours => ShiftEnd - ShiftStart;
        public float NumberOfHours => (float)numberOfHours.TotalMinutes/60.0f;

        [JsonConstructor]
        [BsonConstructor]
        public CompletedShift(string employeeName, DateTime shiftStart, DateTime shiftEnd)
        {
            EmployeeName = employeeName;
            ShiftStart = shiftStart;
            ShiftEnd = shiftEnd;
            IsPaid = false;
            ExpiryDate = DateTime.Now.AddYears(1);
        }

        public CompletedShift()
        {
            
        }
    }
}
