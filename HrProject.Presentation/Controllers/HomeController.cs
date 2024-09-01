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
        private readonly ICariKartService _cariKartService;
        private readonly IOfferService offerService;
        private readonly IOptions<CookieAuthenticationOptions> cookieAuthenticationOptions;
        private readonly IOptionsMonitor<CookieAuthenticationOptions> optionsMonitor;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly INotificationService notificationService;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly ILastActivityService lastActivityService;
        private readonly IProjectModel projectModel;
        private readonly HttpClient client;

        public ApplicationDbContext Context { get; }
        public PhysicalFileProvider operation;
        public string basePath;
        // Root Path in which files and folders are available.
        string root = "wwwroot\\Offer";
        public HomeController(ILogger<HomeController> logger, ICariKartService cariKartService, ApplicationDbContext context, IOfferService offerService, IOptions<CookieAuthenticationOptions> cookieAuthenticationOptions, IOptionsMonitor<CookieAuthenticationOptions> optionsMonitor, SignInManager<ApplicationUser> signInManager, INotificationService notificationService, ApplicationDbContext applicationDbContext, ILastActivityService lastActivityService, IProjectModel projectModel)
        {
            _logger = logger;
            _cariKartService = cariKartService;
            Context = context;
            this.offerService = offerService;
            this.cookieAuthenticationOptions = cookieAuthenticationOptions;
            this.optionsMonitor = optionsMonitor;
            this.signInManager = signInManager;
            this.notificationService = notificationService;
            this.applicationDbContext = applicationDbContext;
            this.lastActivityService = lastActivityService;
            this.projectModel = projectModel;
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
            int onaylananTekliflerCount = offerService.GetCustomerOkOfferCount();

            var redCount = offerService.GetCustomerRedOfferCount();


            int tumuCount = offerService.AllTeklifSayisi();
            var lastActivities = lastActivityService.GetAll().Take(6).ToList();
            ViewBag.LastActivities = lastActivities;
            // Verileri ViewBag ile view'e gönderme
            ViewBag.OnaylananTekliflerCount = onaylananTekliflerCount;
            ViewBag.BekleyenCount = tumuCount - (redCount + onaylananTekliflerCount);
            ViewBag.TumuCount = tumuCount;



            return View();
        }
        public async Task<IActionResult> ProjeIndex()
        {
            var lastActivities = lastActivityService.GetAll().Take(6).ToList();
            ViewBag.LastActivities = lastActivities;
            var tumu = projectModel.GetAll().ToList();
            ViewBag.TumuCount = tumu.Count();
            int baslananlar = tumu.Where(x => x.StartProjectTime.Year != 1).Count();
            ViewBag.Baslananlar = baslananlar;
            ViewBag.BekleyenCount = tumu.Count() - baslananlar;
            return View();

        }
        public async Task GetNeighborhoodAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                for (int offset = 0; offset <= 18000; offset += 1000)
                {
                    var response = await client.GetAsync($"https://turkiyeapi.dev/api/v1/villages?offset={offset}&limit=1000");
                    response.EnsureSuccessStatusCode(); // Eğer HTTP yanıtı başarısızsa bir exception fırlatır.

                    var content = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    var ilceler = applicationDbContext.Districts.ToList();
                    if (apiResponse != null && apiResponse.Data != null)
                    {
                        foreach (var item in apiResponse.Data)
                        {
                            if (item.ProvinceId > 6)
                            {
                                var ilce = ilceler.FirstOrDefault(x => x.Name.ToLower() == item.District.ToLower() && x.CityId == item.ProvinceId);
                                if (ilce != null)
                                {
                                    Neighbourhood neighbourhood = new Neighbourhood();
                                    neighbourhood.DistrictId = ilce.Id;
                                    neighbourhood.Name = item.Name;
                                    neighbourhood.TcpsCode = 9999;
                                    applicationDbContext.Neighbourhoods.Add(neighbourhood);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {

                            }

                        }
                    }
                    applicationDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }



        [HttpGet]
        public async Task<IActionResult> OfferReportBy()
        {
            var keyValue = await offerService.GetReport();

            return Json(keyValue);
        }
        [HttpGet]
        public async Task<IActionResult> OfferReportByUser()
        {
            var offers = offerService.GetOfferInclude().ToList();

            return Json(offers, new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            });

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