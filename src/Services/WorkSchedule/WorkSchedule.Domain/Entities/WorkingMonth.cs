using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;

namespace WorkSchedule.Domain.Entities
{
    public class WorkingMonth : EntityBase
    {
        public string MonthName { get; set; }
        public DateTime MonthStartDate { get; set; }
        public DateTime MonthEndDate { get; set; }
        public IEnumerable<WorkingDay> WorkingDays { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
