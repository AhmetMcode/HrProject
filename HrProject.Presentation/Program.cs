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
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IPersonPositionService, PersonPositionService>();
            builder.Services.AddTransient<IPersonService, PersonService>();
            builder.Services.AddTransient<IPersonSalaryService, PersonSalaryService>();
            builder.Services.AddTransient<IWorkPlaceService, WorkPlaceService>();
            builder.Services.AddTransient<IPersonBonusService, PersonBonusService>();
            builder.Services.AddTransient<IPersonAdvancePaymentService, PersonAdvancePaymentService>();
            builder.Services.AddTransient<IPersonPermissionService, PersonPermissionService>();
            builder.Services.AddTransient<IPersonPermissionTypeService, PersonPermissionTypeService>();
            builder.Services.AddTransient<IPersonAnnualLeaveService, PersonAnnualLeaveService>();
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<ITallyDetailService, TallyDetailService>();
            builder.Services.AddTransient<ITallyDetailService, TallyDetailService>();
            builder.Services.AddTransient<INotificationService, NotificationService>();

            builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            builder.Services.AddTransient<IPersonelAuthorityService, PersonelAuthorityService>();
            builder.Services.AddTransient<IPersonelDocumentService, PersonelDocumentService>();
            builder.Services.AddTransient<IPersonelInterDocService, PersonelInterDocService>();

            builder.Services.AddTransient<ITasksService, TasksService>();

            builder.Services.AddTransient<ILogsKayitService, LogsKayitService>();
            builder.Services.AddTransient<IUserEmailService, UserEmailService>();
            builder.Services.AddTransient<IMessageModuleService, MessageModuleService>();
            builder.Services.AddTransient<IPersonIstenCikarService, PersonIstenCikarService>();
            builder.Services.AddSingleton<PdfService>();
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