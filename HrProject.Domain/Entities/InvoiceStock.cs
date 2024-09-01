using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class InvoiceStock : BaseEntity
    {
        public List<InvoiceStockTax> InvoiceStockTaxs { get; set; }
        public List<InvoiceStockDiscount> InvoiceStockDiscounts { get; set; }
        public InvoiceVATExemptionReasonEnum InvoiceVATExemptionReasonEnum { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public List<StockChange> StockChanges { get; set; }
        public int? UnitId { get; set; }
        public Unit Unit { get; set; }
        public int? SaleVatId { get; set; }
        public SaleVat SaleVat { get; set; }
        public decimal Quantity { get; set; }
        public decimal VATAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal GoodsOrServiceAmount { get; set; }
        public decimal AmountIncludingVat { get; set; }
        public bool? OutStocksOrNot { get; set; }

    }
}
