using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class JsonOfferMaterialDetail
    {
        public List<OfferCostCalculateDetailJson> OfferCostCalculateDetails { get; set; }

    }
    public class OfferCostCalculateJson
    {
        public OfferPart OfferPart { get; set; }
        public List<OfferCostCalculateDetailJson> OfferCostCalculateDetailJson { get; set; }
    }
    public class OfferCostCalculateDetailJson
    {
        public string Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Percent { get; set; }
        public decimal Enflasyon { get; set; }
        public decimal CurrentValueC { get; set; }
        public decimal Wastage { get; set; }
    }
}
