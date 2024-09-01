using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class NotificationSub : BaseEntity
    {
        public string BildirimAd { get; set; }
        public bool SadeceKullanici { get; set; }
        public string Roller { get; set; }
        public bool Zamanli { get; set; }
        public DateTime GonderilecekZaman { get; set; }
        public ApplicationUser Gonderen { get; set; }
        public string? GonderenId { get; set; }
    }
    public class NotificationSubUSer : BaseEntity
    {
        public string AppUserId { get; set; }
        public ApplicationUser AppUser { get; set; }
        public int NotificationSubId { get; set; }
        public NotificationSub NotificationSub { get; set; }

    }
}
