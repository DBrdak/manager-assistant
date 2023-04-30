using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSchedule.Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        [NotMapped]
        private string id { get; set; }

        protected EntityBase()
        {
            if(id is not null && id != string.Empty)
                Id = Guid.Parse(id);
        }
    }
}
