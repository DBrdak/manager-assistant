using System.Text.Json.Serialization;

namespace ManagerAggregator.Models
{
    public class CompletedShiftModel
    {
        public string Id { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public bool IsPaid { get; set; }
        public float NumberOfHours { get; set; }
    }
}
