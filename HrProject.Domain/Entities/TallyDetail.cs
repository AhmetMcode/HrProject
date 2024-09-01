using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class TallyDetail : BaseEntity
    {
        public DateTime DayOfWork { get; set; }
        public double WorkTime { get; set; }
        public int PersonId { get; set; }
        public virtual Person? Person { get; set; }
    }
}
