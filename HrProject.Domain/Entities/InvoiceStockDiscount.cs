using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class InvoiceStockDiscount : BaseEntity
    {
        public int Order { get; set; }
        public int InvoiceStockId { get; set; }
        public InvoiceStock InvoiceStock { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }
        public string? Description { get; set; }

    }
}
