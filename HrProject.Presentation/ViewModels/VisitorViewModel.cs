using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class VisitorViewModel
    {
        public int Id { get; set; }
        public IEnumerable<VisitorEntry> VisitorEntries { get; set; }
        public VisitorEntry VisitorEntry { get; set; }
        public string VisitorName { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
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
