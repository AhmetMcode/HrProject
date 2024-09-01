using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class CalculateOfferCostVM
    {
        public List<OfferCostCategory> OfferCostCategory { get; set; }
        public List<CurrentValue> CurrentValues { get; set; }
        public List<OfferCostCalculateDetail> OfferCostCalculateDetails { get; set; }
        public OfferPart OfferPart { get; set; }
        public Offer Offer { get; set; }
        public string Role { get; set; }
    }
}
