using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class OfferProcess : BaseEntity
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public OfferProcessStage OfferProcessStage { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? ResponsibleUserId { get; set; }
        public ApplicationUser? ResponsibleUser { get; set; }
        public string? StarterUserId { get; set; }
        public ApplicationUser? StarterUser { get; set; }
    }
}
