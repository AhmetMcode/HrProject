using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class OfferPartUpdateViewModel
    {
        public List<OfferPart> OfferParts { get; set; }
        public Offer Offer { get; set; }
        public int OfferId { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Overheads { get; set; }
        public decimal Inflation { get; set; }
    }
}
