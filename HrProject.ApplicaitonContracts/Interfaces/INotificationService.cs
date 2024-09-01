using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface INotificationService : IBaseRepository<Notification>
    {
        public void SendNotification(string senderId, string title, string content, string Recipient, string color);
        public void SendNotificationGrup(string senderId, string title, string content, IList<ApplicationUser> ReceipentGrup, string color);
        public int GetMyNotReadNotificationCount(string userId);
        public List<NotificationDetail> GetMyLast4Notif(string userId);
        public List<NotificationDetail> GetMyNotif(string userId);
        public void ReadNotificationCount(string userId);
        public void SendSms(List<string> phones, string message);
        public Task SendMobileNotifAsync(string baslik, string icerik, string deviceToken);
    }
}
