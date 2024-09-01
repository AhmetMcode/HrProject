using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class InvoiceStockTax : BaseEntity
    {
        public int InvoiceStockId { get; set; }
        public InvoiceStock InvoiceStock { get; set; }
        public InvoiceTaxTypeEnum InvoiceTaxTypeEnum { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }

    }
}
