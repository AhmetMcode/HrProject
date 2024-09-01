using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using RestSharp;
using System.Security.Claims;

namespace HrProject.Presentation.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SendNotification(string baslik, string icerik)
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

            var registrationToken = "dWPmHutDTWuw2fDqcAABHp:APA91bGu7XGnYFLQJ1YRi0HiAZgk72OHzxiQxBOHLEQHYnPgawFa4Njjsjj9bmds_Jk9zqC7HTp2Qh75o9POigMmiGwWyydYs0NsbSaLszZ-S5g3l9ptTmbUY51bFcxOa9eA7dmVI0uG";

            var notification = new Message()
            {
                Token = registrationToken,
                Data = data,
                Notification = new Notification()
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

            // Send the notification

            return Ok();
        }
        public async Task<IActionResult> GetMyNotifications()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notifs = notificationService.GetMyNotif(userId);
            notificationService.ReadNotificationCount(userId);
            return View(notifs);
        }
        public async Task<IActionResult> GetMyNotReadNotificationCount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int count = notificationService.GetMyNotReadNotificationCount(userId);
            return Json(count);
        }
        public async Task<IActionResult> GetMyLast4Notif()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notifs = notificationService.GetMyLast4Notif(userId);
            return Json(notifs);
        }
        public async Task<IActionResult> SendSms()
        {
            var client = new RestSharp.RestClient("https://api.vatansms.net/api/v1/1toN");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            // Replace API_ID, API_KEY, and phone numbers with your actual values
            var body = @"{
                 ""api_id"": ""bc83386712b7f095162e56bc"",
                 ""api_key"": ""e1edb2d40e51ecd7b7326753"",
                 ""sender"": ""HrProject"",
                 ""message_type"": ""normal"",
                 ""message"": ""Sayın Metin Çınar; Teklif Numarası: ELF_23_(S)İON_050  olan Teklifinizinin Sözleşmesi imzalanmıştır bilginize.  Teklif Tutarı : 15.000.789₺ "",
                 ""message_content_type"": ""bilgi"",
                 ""phones"": [
                     ""5511013645,5075929397""


                 ]
            }";

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return Json("işlem ");
        }
    }
}
