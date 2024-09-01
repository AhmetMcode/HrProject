using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime NotificationDate { get; set; }
        public ApplicationUser Sender { get; set; }
        public string SenderId { get; set; }
        public ColorNotification ColorNotification { get; set; }

    }
    public class NotificationDetail : BaseEntity
    {
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string RecipientId { get; set; } // Alıcı kullanıcı
        public ApplicationUser Recipient { get; set; } // Alıcı kullanıcı
        public bool IsRead { get; set; }
    }
    public enum ColorNotification
    {
        Blue,
        Yellow,
        Red,
        Green
    }
}
