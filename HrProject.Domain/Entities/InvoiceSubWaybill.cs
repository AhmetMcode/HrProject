using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class InvoiceSubWaybill : BaseEntity
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int OutWaybill2Id { get; set; }
        public OutWaybill2 OutWaybill2 { get; set; }
        public DateTime OutWaybill2Date { get; set; }
        public string? OutWaybill2Document { get; set; }
    }
}
