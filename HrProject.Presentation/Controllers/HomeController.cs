using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Options;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Attribitues;
using HrProject.Presentation.Data;
using HrProject.Presentation.Models;
using Newtonsoft.Json;
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using UyumsoftTest;

namespace HrProject.Presentation.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOptions<CookieAuthenticationOptions> cookieAuthenticationOptions;
        private readonly IOptionsMonitor<CookieAuthenticationOptions> optionsMonitor;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly INotificationService notificationService;
        private readonly ApplicationDbContext applicationDbContext;
 

        private readonly HttpClient client;

        public ApplicationDbContext Context { get; }
        public PhysicalFileProvider operation;
        public string basePath;
        // Root Path in which files and folders are available.
        string root = "wwwroot\\Offer";
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IOptions<CookieAuthenticationOptions> cookieAuthenticationOptions, IOptionsMonitor<CookieAuthenticationOptions> optionsMonitor, SignInManager<ApplicationUser> signInManager, INotificationService notificationService, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            Context = context;

            this.cookieAuthenticationOptions = cookieAuthenticationOptions;
            this.optionsMonitor = optionsMonitor;
            this.signInManager = signInManager;
            this.notificationService = notificationService;
            this.applicationDbContext = applicationDbContext;


        }
        public async Task<IActionResult> Index2()
        {
            string sCookieHeader = Request.Headers["Cookie"];
            var currentUser = await signInManager.UserManager.GetUserAsync(User);
            var expirationTime = await signInManager.UserManager.GetLockoutEndDateAsync(currentUser);

            var _expireTimeSpan = optionsMonitor.CurrentValue.ExpireTimeSpan;
            var _expireTimeSpan2 = optionsMonitor.CurrentValue.Cookie.MaxAge;


            return View();
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (User.IsInRole(Roller.Role_Planlama_Sef))
            {

            }
            if (User.IsInRole(Roller.Role_Teklif_Yonetici))
            {

            }
            if (User.IsInRole(Roller.Role_Proje_Calisan) || User.IsInRole(Roller.Role_Proje_Yonetici))
            {
                return RedirectToAction("ProjeIndex");
            }
 



            return View();
        }
        public async Task<IActionResult> ProjeIndex()
        {
 
            return View();

        }




       public async Task<IActionResult> Deneme()
        {
            return View();
        }
        public string Resim()
        {
            return "logo";
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class ApiResponse
    {
        public List<Neighborhood2> Data { get; set; }
    }
    public class IlceListe
    {
        public IlceData[] Data { get; set; }
    }

    public class IlceData
    {
        public string IlceKodu { get; set; }
        public string IlceAdi { get; set; }
    }
    public class Feature
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string Text { get; set; }
        public int Id { get; set; }
        // Diğer özellikleri ekleyebilirsiniz.
    }

    public class Neighborhood2
    {
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int Id { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }

    public class RootObject
    {
        public List<Feature> Features { get; set; }
        public string type { get; set; }
        // Diğer gerekli özellikleri ekleyebilirsiniz.
    }
}