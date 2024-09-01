using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class VisitorEntry : BaseEntity
    {
        public string VisitorName { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public string? PersonPosition { get; set; }
        public string? PhoneNo { get; set; }
        public string? CarInfo { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public string? Description { get; set; }
        public VisitReason VisitReason { get; set; }
        public VisitorStatus VisitorStatus { get; set; }

    }
}
