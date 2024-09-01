using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OfferProjectDocuments : BaseEntity
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public string Document1 { get; set; }
        public string? Document2 { get; set; }
        public string? Document3 { get; set; }
        public string? Document4 { get; set; }
        public string? Document5 { get; set; }
        public string? Document6 { get; set; }
    }
}
