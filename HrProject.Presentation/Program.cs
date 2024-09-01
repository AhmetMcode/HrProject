using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Application;
using HrProject.Application.Services;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Presentation.Models;
using Rotativa.AspNetCore;
using System.Globalization;

namespace HrProject.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Models.AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Full Admin"));
            });
            builder.Services.AddSingleton(mapper);
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My MVC App", Version = "v1" });
            });

            #region ImplementServices
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddSignalR();


            builder.Services.AddTransient<ICariKartService, CariKartService>();
            builder.Services.AddTransient<ICityService, CityService>();
            builder.Services.AddTransient<ITaxOfficeService, TaxOfficeService>();
            builder.Services.AddTransient<ICariBankService, CariBankService>();
            builder.Services.AddTransient<ICariRiskService, CariRiskService>();
            builder.Services.AddTransient<IDistrictService, DistrictService>();
            builder.Services.AddTransient<IInvoiceAdressService, InvoiceAdressService>();
            builder.Services.AddTransient<IOtherCariRiskService, OtherCariRiskService>();
            builder.Services.AddTransient<IOfferService, OfferService>();
            builder.Services.AddTransient<ICurrentValueService, CurrentValueService>();
            builder.Services.AddTransient<IProjectService, ProjectService>();
            builder.Services.AddTransient<IProjectTypeService, ProjectTypeService>();
            builder.Services.AddTransient<ICurrentValueService, CurrentValueService>();
            builder.Services.AddTransient<ICurrentValueChangeService, CurrentValueChangeService>();
            builder.Services.AddTransient<IUnitService, UnitService>();
            builder.Services.AddTransient<INeighbourhoodService, NeighbourhoodService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IOfferProcessService, OfferProcessService>();
            builder.Services.AddTransient<IStockService, StockService>();
            builder.Services.AddTransient<IStockCategoryService, StockCategoryService>();
            builder.Services.AddTransient<IStockChangeService, StockChangeService>();
            builder.Services.AddTransient<IStockChangeService, StockChangeService>();
            builder.Services.AddTransient<IWareHouseService, WareHouseService>();
            builder.Services.AddTransient<IPersonPositionService, PersonPositionService>();
            builder.Services.AddTransient<IPersonService, PersonService>();
            builder.Services.AddTransient<IPersonSalaryService, PersonSalaryService>();
            builder.Services.AddTransient<IWorkPlaceService, WorkPlaceService>();
            builder.Services.AddTransient<IPersonBonusService, PersonBonusService>();
            builder.Services.AddTransient<IBuyingWithholdingRateService, BuyingWithholdingRateService>();
            builder.Services.AddTransient<IBuyingWithholdingTypeService, BuyingWithholdingTypeService>();
            builder.Services.AddTransient<IEDocumentBaseRateService, EDocumentBaseRateService>();
            builder.Services.AddTransient<IPurchaseVatService, PurchaseVatService>();
            builder.Services.AddTransient<ISaleVatService, SaleVatService>();
            builder.Services.AddTransient<ISalesWithholdingRateService, SalesWithholdingRateService>();
            builder.Services.AddTransient<ISalesWithholdingTypeService, SalesWithholdingTypeService>();
            builder.Services.AddTransient<IPersonAdvancePaymentService, PersonAdvancePaymentService>();
            builder.Services.AddTransient<IPersonPermissionService, PersonPermissionService>();
            builder.Services.AddTransient<IPersonPermissionTypeService, PersonPermissionTypeService>();
            builder.Services.AddTransient<IPersonAnnualLeaveService, PersonAnnualLeaveService>();
            builder.Services.AddTransient<IPersonPermissionRuleService, PersonPermissionRuleService>();
            builder.Services.AddTransient<IPersonPermissionTransferService, PersonPermissionTransferService>();
            builder.Services.AddTransient<IPersonPermissionPaymentService, PersonPermissionPaymentService>();
            builder.Services.AddTransient<IGoodsCodeService, GoodsCodeService>();
            builder.Services.AddTransient<IFirstOfferService, FirstOfferService>();
            builder.Services.AddTransient<ISubFirstOfferService, SubFirstOfferService>();
            builder.Services.AddTransient<IDetailOfferService, DetailOfferService>();

            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IOfferMessageService, OfferMessageService>();
            builder.Services.AddTransient<ITallyDetailService, TallyDetailService>();
            builder.Services.AddTransient<IStockMoveService, StockMoveService>();
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IBankService, BankService>();
            builder.Services.AddTransient<IMoneyTransfersService, MoneyTransfersService>();
            builder.Services.AddTransient<IFollowCurrencyRateService, FollowCurrencyRateService>();


            builder.Services.AddTransient<IGoodsCodeService, GoodsCodeService>();
            builder.Services.AddTransient<ITallyDetailService, TallyDetailService>();
            builder.Services.AddTransient<IFirstOfferService, FirstOfferService>();
            builder.Services.AddTransient<ISubFirstOfferService, SubFirstOfferService>();
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IOfferMessageService, OfferMessageService>();
            builder.Services.AddTransient<IProjectElementTypeService, ProjectElementTypeService>();
            builder.Services.AddTransient<IOfferCostCategory, OfferCostCategoryService>();
            builder.Services.AddTransient<IOfferMaterials, OfferMaterialsService>();
            builder.Services.AddTransient<IProjectModel, ProjectModelService>();
            builder.Services.AddTransient<IOutWaybillService, OutWaybillService>();
            builder.Services.AddTransient<IOutWaybillChangeService, OutWaybillChangeService>();
            builder.Services.AddTransient<IInWaybillService, InWaybillService>();
            builder.Services.AddTransient<IInWaybillChangeService, InWaybillChangeService>();
            builder.Services.AddTransient<IStockPastService, StockPastService>();
            builder.Services.AddTransient<IChecksService, ChecksService>();
            builder.Services.AddTransient<IPatternService, PatternService>();
            builder.Services.AddTransient<IVisitorEntryService, VisitorEntryService>();
            builder.Services.AddTransient<IProductionPlace, ProductionPlaceService>();
            builder.Services.AddTransient<IActivePatternPlan, ActivePatternPlanService>();
            builder.Services.AddTransient<IProductPlanSubPlanned, ProductPlanSubPlannedService>();
            builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            builder.Services.AddTransient<IVehicleService, VehicleService>();
            builder.Services.AddTransient<IFuelTransferService, FuelTransferService>();
            builder.Services.AddTransient<IMaintenancesStockService, MaintenancesStockService>();
            builder.Services.AddTransient<IMaintenanceServiceService, MaintenanceServiceService>();
            builder.Services.AddTransient<IMaintenanceRequestService, MaintenanceRequestService>();
            builder.Services.AddTransient<IMaintenanceRequestListServiceService, MaintenanceRequestListServiceService>();
            builder.Services.AddTransient<IVehicleCategoryService, VehicleCategoryService>();
            builder.Services.AddTransient<IMaintenanceServiceCategoryService, MaintenanceServiceCategoryService>();
            builder.Services.AddTransient<IMaintenancesStockService, MaintenancesStockService>();
            builder.Services.AddTransient<IMaintenanceServiceService, MaintenanceServiceService>();
            builder.Services.AddTransient<IMaintenanceRequestService, MaintenanceRequestService>();
            builder.Services.AddTransient<IMaintenanceRequestListServiceService, MaintenanceRequestListServiceService>();
            builder.Services.AddTransient<IVehicleCategoryService, VehicleCategoryService>();
            builder.Services.AddTransient<IMealCategoryService, MealCategoryService>();
            builder.Services.AddTransient<INewFoodService, NewFoodService>();
            builder.Services.AddTransient<IMealService, MealService>();
            builder.Services.AddTransient<IFoodNameService, FoodNameService>();
            builder.Services.AddTransient<IMenuService, MenuService>();
            builder.Services.AddTransient<IMenuDetailsService, MenuDetailsService>();
            builder.Services.AddTransient<IMaintenancesStockService, MaintenancesStockService>();
            builder.Services.AddTransient<IMaintenanceServiceService, MaintenanceServiceService>();
            builder.Services.AddTransient<IMaintenanceRequestService, MaintenanceRequestService>();
            builder.Services.AddTransient<IMaintenanceRequestListServiceService, MaintenanceRequestListServiceService>();
            builder.Services.AddTransient<IVehicleCategoryService, VehicleCategoryService>();
            builder.Services.AddTransient<IProductionStepService, ProductionStepService>();
            builder.Services.AddTransient<IProjectElementStepService, ProjectElementStepService>();
            builder.Services.AddTransient<IProductManifact, ProductManifactService>();
            builder.Services.AddTransient<IProductManifactDetail, ProductManifactDetailService>();
            builder.Services.AddTransient<IQualityFormSub, QualityFormSubService>();
            builder.Services.AddTransient<IHesapSiniflariService, HesapSiniflariService>();
            builder.Services.AddTransient<IHesapGruplariService, HesapGruplariService>();
            builder.Services.AddTransient<IHesapPlaniService, HesapPlaniService>();
            builder.Services.AddTransient<IHesapMuavinService, HesapMuavinService>();
            builder.Services.AddTransient<IHesapTaliService, HesapTaliService>();
            builder.Services.AddTransient<IHesapDetayService, HesapDetayService>();
            builder.Services.AddTransient<IInvoiceStockTaxService, InvoiceStockTaxService>();
            builder.Services.AddTransient<IInvoiceStockService, InvoiceStockService>();
            builder.Services.AddTransient<IInvoiceStockDiscountService, InvoiceStockDiscountService>();
            builder.Services.AddTransient<IInvoiceSubWaybillService, InvoiceSubWaybillService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddTransient<IInvoiceAdditionalDocumentService, InvoiceAdditionalDocumentService>();
            builder.Services.AddTransient<IInvoiceGoodsAcceptanceService, InvoiceGoodsAcceptanceService>();
            builder.Services.AddTransient<IPersonelAuthorityService, PersonelAuthorityService>();
            builder.Services.AddTransient<IPersonelDocumentService, PersonelDocumentService>();
            builder.Services.AddTransient<IPersonelInterDocService, PersonelInterDocService>();
            builder.Services.AddTransient<IPersAddDocService, PersAddDocService>();
            builder.Services.AddTransient<ISalesOfferService, SalesOfferService>();
            builder.Services.AddTransient<ISalesDetailOfferService, SalesDetailOfferService>();
            builder.Services.AddTransient<ISalesBaseOfferService, SalesBaseOfferService>();
            builder.Services.AddTransient<IProductStepNotifService, ProductStepNotifService>();
            builder.Services.AddTransient<IConcreteRequest, ConcreteRequestService>();
            builder.Services.AddTransient<ICustomerInteractionOfferService, CustomerInteractionOfferService>();
            builder.Services.AddTransient<ILastActivityService, LastActivityService>();
            builder.Services.AddTransient<ITasksService, TasksService>();
            builder.Services.AddTransient<IPmCalculateDocumentService, PmCalculateDocumentService>();
            builder.Services.AddTransient<IPmCalculateService, PmCalculateService>();
            builder.Services.AddTransient<ILogsKayitService, LogsKayitService>();
            builder.Services.AddTransient<IUserEmailService, UserEmailService>();
            builder.Services.AddTransient<IFileProjeModulService, FileProjeModulService>();
            builder.Services.AddTransient<IQuestionService, QuestionService>();
            builder.Services.AddTransient<IMessageModuleService, MessageModuleService>();
            builder.Services.AddTransient<IUretimOnayLogService, UretimOnayLogService>();
            builder.Services.AddTransient<IProductDailyPlanService, ProductDailyPlanService>();
            builder.Services.AddTransient<IProductPlanProductPlannedService, ProductPlanProductPlannedService>();
            builder.Services.AddTransient<IHolNesneService, HolNesneService>();
            builder.Services.AddTransient<ILabaratuarSonucService, LabaratuarSonucService>();
            builder.Services.AddTransient<IPersonIstenCikarService, PersonIstenCikarService>();
            builder.Services.AddSingleton<PdfService>();
            builder.Services.AddTransient<ISafetyIssueService, SafetyIssueService>();
            builder.Services.AddTransient<IKaliteBirimAtamaService, KaliteBirimAtamaService>();
            builder.Services.AddTransient<ISayimService, SayimService>();
            builder.Services.AddTransient<IRopeIronPmService, RopeIronPmService>();
            #endregion
            builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 104857600;

            });
            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = 104857600;
            });
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNetCore.Identity.Application";
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccesDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.Cookie.MaxAge = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;

                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.Redirect("/Identity/Account/Login");
                    return Task.CompletedTask;
                };
            });
            var configuration = builder.Configuration;
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<OfferService>();

            builder.Services.AddScoped<BackgroundJobs>();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            CultureInfo turkishCulture = new CultureInfo("tr-TR");
            turkishCulture.NumberFormat.NumberDecimalSeparator = ".";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2UVhhQlVFfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTX5QdkNiWX9acndWQmBd");
            CultureInfo.DefaultThreadCurrentCulture = turkishCulture;
            CultureInfo.DefaultThreadCurrentUICulture = turkishCulture;



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapRazorPages();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My MVC App V1");
            });
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
            app.MapControllers();


            app.Run();
        }
    }
}