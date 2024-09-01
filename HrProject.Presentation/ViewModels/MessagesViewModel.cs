using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class MessagesViewModel
    {
        public OfferMessages OfferMessages { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
