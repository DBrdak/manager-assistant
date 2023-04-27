using WorkSchedule.Domain.Common;

namespace WorkSchedule.Domain.Entities;

public class Shift : EntityBase
{
    public string EmployeeName { get; set; }
    public string Note { get; set; }
    public string StartHour { get; set; }
    public string EndHour { get; set; }
}