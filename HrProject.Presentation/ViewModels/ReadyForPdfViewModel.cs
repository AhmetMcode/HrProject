using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class ReadyForPdfViewModel
    {
        public List<OfferPart> OfferParts { get; set; }
        public List<OfferTechnicalByOffer> OfferTechnicalByOffers { get; set; }
        public Offer Offer { get; set; }
    }
}
