using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OfferMessages : BaseEntity
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public List<OfferMessagesDetail> OfferMessagesDetail { get; set; }
    }
    public class OfferMessagesDetail : BaseEntity
    {
        public int OfferMessagesId { get; set; }
        public OfferMessages OfferMessages { get; set; }
        public string Message { get; set; }
        public string SenderUserId { get; set; }
        public ApplicationUser SenderUser { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
