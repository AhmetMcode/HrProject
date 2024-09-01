using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class CustomerInteractionOffer : BaseEntity
    {
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Notes { get; set; }
        public string? ColorCustomer { get; set; }
        public DateTime InteractionDate { get; set; }
        public DateTime HatirlatTarih { get; set; }
    }
}
