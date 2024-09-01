using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class DetailOffer : BaseEntity
    {
        public int FirstOfferId { get; set; }
        public FirstOffer FirstOffer { get; set; }
        public OfferType OfferType { get; set; }
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public int GoodsCodeId { get; set; }
        public GoodsCode GoodsCode { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Qantity { get; set; }
        public string UnitType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal NetPrice { get; set; }
        public bool IsVat { get; set; }
        public int PurchaseVatId { get; set; }
        public PurchaseVat PurchaseVat { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PriceValidityDate { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentLastDate { get; set; }
        public string? Description { get; set; }

    }
}
