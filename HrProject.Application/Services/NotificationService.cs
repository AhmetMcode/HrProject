using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using HrProject.Repository.Repositories.Interfaces;
using RestSharp;

namespace HrProject.Application.Services
{
    public class NotificationService : BaseRepository<Domain.Entities.Notification>, INotificationService
    {
        private readonly IVisitorEntryService visitorEntryService;

        public NotificationService(DbContextOptions<ApplicationDbContext> options, IVisitorEntryService visitorEntryService) : base(options)
        {
            this.visitorEntryService = visitorEntryService;
        }

        public bool ExistsByProperty<TProperty>(System.Linq.Expressions.Expression<Func<Domain.Entities.Notification, TProperty>> propertySelector, TProperty value)
        {
            throw new NotImplementedException();
        }

        public List<NotificationDetail> GetMyLast4Notif(string userId)
        {
            return _context.NotificationDetails
                    .Where(x => x.IsRead == false && x.RecipientId == userId).Include(x => x.Notification)
                    .OrderByDescending(x => x.Id)
                    .Take(4)
                    .ToList();
        }
        public List<NotificationDetail> GetMyNotif(string userId)
        {
            return _context.NotificationDetails
                    .Where(x => x.RecipientId == userId).Include(x => x.Notification).ThenInclude(x => x.Sender)
                    .OrderByDescending(x => x.Id)
                    .ToList();
        }
        public int GetMyNotReadNotificationCount(string userId)
        {
            return _context.NotificationDetails.Where(x => x.IsRead == false && x.RecipientId == userId).ToList().Count();
        }

        public Domain.Entities.Notification Insert(Domain.Entities.Notification entity)
        {
            throw new NotImplementedException();
        }

        public void ReadNotificationCount(string userId)
        {
            var details = _context.NotificationDetails.Where(x => x.RecipientId == userId).ToList();

            foreach (var notification in details)
            {
                notification.IsRead = true;
            }

            _context.UpdateRange(details);
            _context.SaveChanges();
        }

        public async Task SendMobileNotifAsync(string baslik, string icerik, string deviceToken)
        {
            // Your notification logic goes here
            var message = new Dictionary<string, string>()
        {
            { "title", baslik },
            { "body", icerik }
        };

            var data = new Dictionary<string, string>()
        {
            { "key1", "merhaba" },
            { "key2", "merhaba2" }
        };

            var registrationToken = deviceToken;

            var notification = new Message()
            {
                Token = registrationToken,
                Data = data,
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = message["title"],
                    Body = message["body"]
                }
            };
            try
            {

                var response = await FirebaseMessaging.DefaultInstance.SendAsync(notification);
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.ToString());
            }
        }

        public void SendNotification(string senderId, string title, string content, string Recipient, string color)
        {
            Domain.Entities.Notification notification = new Domain.Entities.Notification();
            notification.SenderId = senderId;
            notification.Title = title;
            notification.Content = content;
            notification.NotificationDate = DateTime.Now;
            notification.ColorNotification = ColorNotification.Blue;
            NotificationDetail detail = new NotificationDetail();
            detail.RecipientId = Recipient;
            detail.IsRead = false;
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            detail.NotificationId = notification.Id;
            _context.NotificationDetails.Add(detail);
            _context.SaveChanges();

        }

        public void SendNotificationGrup(string senderId, string title, string content, IList<ApplicationUser> ReceipentGrup, string color)
        {
            Domain.Entities.Notification notification = new Domain.Entities.Notification();
            notification.SenderId = senderId;
            notification.Title = title;
            notification.Content = content;
            notification.NotificationDate = DateTime.Now;
            notification.ColorNotification = ColorNotification.Blue;
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            foreach (var item in ReceipentGrup)
            {
                NotificationDetail detail = new NotificationDetail();
                detail.NotificationId = notification.Id;
                detail.RecipientId = item.Id;
                detail.IsRead = false;
                _context.NotificationDetails.Add(detail);
            }
            _context.SaveChanges();

        }

        public async void SendSms(List<string> phones, string message)
        {
            var client = new RestSharp.RestClient("https://api.vatansms.net/api/v1/1toN");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            // Replace API_ID, API_KEY, and sender with your actual values
            var body = @"{
         ""api_id"": ""bc83386712b7f095162e56bc"",
         ""api_key"": ""e1edb2d40e51ecd7b7326753"",
         ""sender"": ""HrProject"",
         ""message_type"": ""normal"",
         ""message"": """ + message + @""",
         ""message_content_type"": ""bilgi"",
         ""phones"": [";

            // Concatenate phone numbers
            for (int i = 0; i < phones.Count; i++)
            {
                body += "\"" + phones[i] + "\"";
                if (i < phones.Count - 1)
                {
                    body += ",";
                }
            }

            body += @"]
    }";

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
        }


        public void SendSms(List<string> sms)
        {
            throw new NotImplementedException();
        }

        public void SendTerminNotification(string userId, string message)
        {
            var deviceToken = visitorEntryService.GetTokenUser(userId);
            if (deviceToken != null)
            {
                SendMobileNotifAsync("Termin", message, deviceToken.Token);
            }
        }

        public void Update(Domain.Entities.Notification entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Notification> Where(Func<Domain.Entities.Notification, bool> filter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Domain.Entities.Notification> IBaseRepository<Domain.Entities.Notification>.GetAll()
        {
            throw new NotImplementedException();
        }

        Domain.Entities.Notification IBaseRepository<Domain.Entities.Notification>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
