using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class SalesDetailOffer : BaseEntity
    {
        public int SalesOfferId { get; set; }
        public SalesOffer SalesOffer { get; set; }
        public OfferType OfferType { get; set; }
        public string? ServiceText { get; set; }
        public int? StockId { get; set; }
        public Stock Stock { get; set; }
        public decimal Quantity { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal CurrencyTotal { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetPrice { get; set; }
        public int PurchaseVatId { get; set; }
        public PurchaseVat PurchaseVat { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Description { get; set; }
    }
}
