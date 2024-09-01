using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class SubFirstOffer : BaseEntity
    {
        public FirstOfferStatusEnum FirstOfferStatusEnum { get; set; }
        public bool IsActive { get; set; }
        public string StarterUserId { get; set; }
        public ApplicationUser StarterUser { get; set; }
        public string Name { get; set; }

    }
}
