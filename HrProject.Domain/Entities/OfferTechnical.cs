using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OfferTechnical : BaseEntity
    {
        public string Name { get; set; }
        public string? DefaultValue { get; set; }
        public int Order { get; set; }
    }
    public class OfferTechnicalByOffer : BaseEntity
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public OfferTechnical OfferTechnical { get; set; }
        public int OfferTechnicalId { get; set; }
    }
}
