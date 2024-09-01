using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class InvoiceAdditionalDocument : BaseEntity
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public string? No { get; set; }
        public DateTime Date { get; set; }
        public string? Type { get; set; }
        public string? File { get; set; }
    }
}
