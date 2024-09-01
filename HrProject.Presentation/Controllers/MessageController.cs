using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using System.Security.Claims;

namespace HrProject.Presentation.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageModuleService messageModuleService;
        private readonly UserManager<ApplicationUser> userManager;

        public MessageController(IMessageModuleService messageModuleService, UserManager<ApplicationUser> userManager)
        {
            this.messageModuleService = messageModuleService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string ben = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Ben = ben;
            ViewBag.BenNesne = await userManager.FindByIdAsync(ben);
            return View();
        }
        public IActionResult AllUsersJson()
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var messages = messageModuleService
                .Where(x => x.AlanId == currentUserId || x.GonderenId == currentUserId)
                .GroupBy(x => x.AlanId == currentUserId ? x.GonderenId : x.AlanId)
                .Select(g => new
                {
                    UserId = g.Key,
                    LastMessageDate = g.Max(m => m.GonderilmeZamani)
                })
                .ToList();

            var users = userManager.Users.ToList();

            var sortedUsers = users
                .GroupJoin(messages,
                           u => u.Id,
                           m => m.UserId,
                           (user, userMessages) => new
                           {
                               User = user,
                               LastMessageDate = userMessages.Any() ? userMessages.Max(m => m.LastMessageDate) : (DateTime?)null
                           })
                .OrderByDescending(u => u.LastMessageDate)
                .Select(u => u.User)
                .ToList();

            return Json(sortedUsers);

        }
        public async Task<IActionResult> SonOnMesajGetir(string AlanId)
        {
            string gonderenId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var sonOnMesaj = messageModuleService
                  .Where(x => (x.GonderenId == gonderenId && x.AlanId == AlanId) || (x.GonderenId == AlanId && x.AlanId == gonderenId))
                  .OrderBy(x => x.GonderilmeZamani)
                  .Take(10)
                  .ToList();
            var user = await userManager.FindByIdAsync(AlanId);
            var result = new
            {
                Messages = sonOnMesaj,
                User = user
            };
            return Json(result);
        }
        public IActionResult SendMessage(string gonderilcekUserId, string mesajIcerik)
        {
            string gonderenId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MessageModule messageModule = new MessageModule();
            messageModule.AlanId = gonderilcekUserId;
            messageModule.Iletildi = true;
            messageModule.Belge = false;
            messageModule.GonderenId = "";
            messageModule.Mesaj = mesajIcerik;
            messageModule.GonderenId = gonderenId;
            messageModule.GonderilmeZamani = DateTime.Now;
            messageModuleService.Insert(messageModule);
            return Json("Tamam");
        }

    }
}
