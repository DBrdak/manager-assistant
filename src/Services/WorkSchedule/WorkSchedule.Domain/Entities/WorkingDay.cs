using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;

namespace WorkSchedule.Domain.Entities
{
    public class WorkingDay : EntityBase
    {
        public DateTime Date { get; set; }
        public IEnumerable<Shift> Shifts { get; set; } = new List<Shift>();
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
    }
}
