using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class SalesOfferViewModel
    {
        public int Id { get; set; }
        public IEnumerable<SalesOffer> SalesOffers { get; set; }
        public int SalesOfferId { get; set; }
        public SalesOffer SalesOffer { get; set; }
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public string Name { get; set; }
        public DateTime TermDate { get; set; }
        public IFormFile? Document { get; set; }
        public string? Description { get; set; }
        public List<SalesDetailOffer> SalesDetailOffers { get; set; }
        public int SalesDetailOfferId { get; set; }
        public SalesDetailOffer SalesDetailOffer { get; set; }
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

        public decimal GeneralVATTotal { get; set; }
        public decimal GeneralTotal { get; set; }
        public SalesOfferProcess SalesOfferProcess { get; set; }

    }
}
