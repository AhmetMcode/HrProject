using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HrProject.Domain.Entities;
using HrProject.Domain.Entities.Base;

namespace HrProject.Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CariKart> CariKarts { get; set; }
        public DbSet<TaxOffice> TaxOffices { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<InvoiceAdress> InvoiceAdress { get; set; }
        public DbSet<CariBank> CariBanks { get; set; }
        public DbSet<CariRisk> CariRisks { get; set; }
        public DbSet<OtherCariRisk> OtherCariRisks { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<CurrentValue> CurrentValues { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<CurrentValueChange> CurrentValueChanges { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
        public DbSet<OfferProcess> OfferProcess { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockChange> StockChanges { get; set; }
        public DbSet<StockCategory> StockCategories { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<OfferProjectDocuments> OfferProjectDocuments { get; set; }
        public DbSet<Person> Personals { get; set; }
        public DbSet<PersonPosition> PersonPosition { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<PersonSalary> PersonSalaries { get; set; }
        public DbSet<ProjectElement> ProjectElements { get; set; }
        public DbSet<ConcreteClass> ConcreteClass { get; set; }
        public DbSet<OfferCalculate> OfferCalculates { get; set; }
        public DbSet<IronDiameterWeight> IronDiameterWeights { get; set; }
        public DbSet<SteelMeshType> SteelMeshType { get; set; }
        public DbSet<ToronDiameter> ToronDiameters { get; set; }
        public DbSet<ProjectElementDetails> ProjectElementDetails { get; set; }
        public DbSet<WickerIronCalculate> WickerIronCalculate { get; set; }
        public DbSet<RopeIron> RopeIrons { get; set; }
        public DbSet<AnkrajIron> AnkrajIrons { get; set; }
        public DbSet<BuyingWithholdingRate> BuyingWithholdingRates { get; set; }
        public DbSet<BuyingWithholdingType> BuyingWithholdingTypes { get; set; }
        public DbSet<EDocumentBaseRate> EDocumentBaseRates { get; set; }
        public DbSet<SalesWithholdingRate> SalesWithholdingRates { get; set; }
        public DbSet<SalesWithholdingType> SalesWithholdingTypes { get; set; }
        public DbSet<SaleVat> SaleVats { get; set; }
        public DbSet<PurchaseVat> PurchaseVats { get; set; }
        public DbSet<PersonAdvancePayment> PersonAdvancePayments { get; set; }
        public DbSet<PersonPermissionPayment> PersonPermissionPayments { get; set; }
        public DbSet<PersonPermissionTransfer> PersonPermissionTransfer { get; set; }
        public DbSet<PersonPermissionRule> PersonPermissionRules { get; set; }
        public DbSet<PersonAnnualLeave> PersonAnnualLeaves { get; set; }
        public DbSet<PersonPermissionType> PersonPermissionTypes { get; set; }
        public DbSet<PersonPermission> PersonPermissions { get; set; }
        public DbSet<SubFirstOffer> SubFirstOffers { get; set; }
        public DbSet<FirstOffer> FirstOffers { get; set; }
        public DbSet<DetailOffer> DetailOffers { get; set; }
        public DbSet<TallyDetail> TallyDetails { get; set; }
        public DbSet<OfferPart> OfferParts { get; set; }
        public DbSet<GoodsCode> GoodsCodes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationDetail> NotificationDetails { get; set; }
        public DbSet<OfferMessages> OfferMessages { get; set; }
        public DbSet<OfferMessagesDetail> OfferMessagesDetails { get; set; }
        public DbSet<StockMove> StockMoves { get; set; }
        public DbSet<ProjectElementType> ProjectElementTypes { get; set; }
        public DbSet<OfferCostCategory> OfferCostCategorys { get; set; }
        public DbSet<OfferMaterials> OfferMaterials { get; set; }
        public DbSet<OfferCostCalculateDetail> OfferCostCalculateDetails { get; set; }
        public DbSet<OfferTechnical> OfferTechnicals { get; set; }
        public DbSet<OfferTechnicalByOffer> OfferTechnicalByOffers { get; set; }
        public DbSet<ProjectModuleSub> ProjectModuleSub { get; set; }
        public DbSet<ProjectModuleStatus> ProjectModuleStatus { get; set; }
        public DbSet<OutWaybill2> OutWaybills2 { get; set; }
        public DbSet<Bank2> Banks2 { get; set; }
        public DbSet<Account2> Accounts2 { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }
        public DbSet<FollowCurrencyRate> FollowCurrencyRates { get; set; }
        public DbSet<InWaybill> InWaybills { get; set; }
        public DbSet<FileUploadLog> FileUploadLog { get; set; }
        public DbSet<PmCalculate> PmCalculates { get; set; }
        public DbSet<PMProjectElementDetails> PMProjectElementDetails { get; set; }
        public DbSet<PMWickerIronCalculate> PMWickerIronCalculates { get; set; }
        public DbSet<PmRopeIron> PmRopeIrons { get; set; }
        public DbSet<PmAnkrajIron> PmAnkrajIrons { get; set; }
        public DbSet<ProductionDrawing> ProductionDrawings { get; set; }
        public DbSet<OutWaybillChange> OutWaybillChanges { get; set; }
        public DbSet<InWaybillChange> InWaybillChanges { get; set; }
        public DbSet<StockPast> StockPasts { get; set; }
        public DbSet<Checks> Checkses { get; set; }
        public DbSet<ProductPlace> ProductPlaces { get; set; }
        public DbSet<Pattern> Patterns { get; set; }
        public DbSet<PatternProjectElementType> PatternProjectElementType { get; set; }
        public DbSet<VisitorEntry> VisitorEntries { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<FuelTransfer> FuelTransfers { get; set; }
        public DbSet<ProductionPlace> ProductionPlaces { get; set; }
        public DbSet<ActivePatternPlan> ActivePatternPlan { get; set; }
        public DbSet<ProductPlanSubPlanned> ProductPlanSubPlanned { get; set; }
        public DbSet<ProductPlanDailyPlanned> ProductPlanDailyPlanned { get; set; }
        public DbSet<ProductPlanProductPlanned> ProductPlanProductPlanned { get; set; }
        public DbSet<ProductPlan> ProductPlan { get; set; }
        public DbSet<OfferTerminSub> OfferTerminSub { get; set; }
        public DbSet<OfferTerminDetail> OfferTerminDetail { get; set; }

        public DbSet<MaintenancesStock> MaintenancesStocks { get; set; }
        public DbSet<MaintenanceService> MaintenanceServices { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<MaintenanceRequestListService> MaintenanceRequestListServices { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<MaintenanceServiceCategory> MaintenanceServiceCategories { get; set; }
        public DbSet<MealCategory> MealCategories { get; set; }
        public DbSet<NewFood> NewFoods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<FoodName> FoodNames { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuDetails> MenuDetailses { get; set; }
        public DbSet<MobileToken> MobileToken { get; set; }
        public DbSet<ProductionStep> ProductionStep { get; set; }
        public DbSet<ProjectElementStep> ProjectElementStep { get; set; }
        public DbSet<ProductManifact2> ProductManifacts2 { get; set; }
        public DbSet<ProductManifactDetail> ProductManifactDetails { get; set; }
        public DbSet<ProductManifactDetailImages> ProductManifactDetailImages { get; set; }
        public DbSet<ManifactStepType> ManifactStepTypes { get; set; }
        public DbSet<InfoCompany> InfoCompany { get; set; }
        public DbSet<LogoMobil> LogoMobil { get; set; }
        public DbSet<StockSub> StockSub { get; set; }
        public DbSet<PersonMounthPayment> PersonMounthPayments { get; set; }
        public DbSet<QualityFormSub> QualityFormSub { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QualityFormSubAnswer> QualityFormSubAnswer { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<HesapSiniflari> HesapSiniflaris { get; set; }
        public DbSet<HesapGruplari> HesapGruplaris { get; set; }
        public DbSet<HesapPlani> HesapPlanis { get; set; }
        public DbSet<HesapMuavin> HesapMuavins { get; set; }
        public DbSet<HesapTali> HesapTalis { get; set; }
        public DbSet<HesapDetay> HesapDetays { get; set; }
        public DbSet<ManifactReport> ManifactReports { get; set; }
        public DbSet<DailyManifactReport> DailyManifactReports { get; set; }
        public DbSet<DailyManifactReportDetail> DailyManifactReportDetails { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<AlperenUretim> AlperenUretims { get; set; }
        public DbSet<InvoiceStockTax> InvoiceStockTaxs { get; set; }
        public DbSet<InvoiceStock> InvoiceStocks { get; set; }
        public DbSet<InvoiceStockDiscount> InvoiceStockDiscounts { get; set; }
        public DbSet<InvoiceSubWaybill> InvoiceSubWaybills { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceAdditionalDocument> InvoiceAdditionalDocuments { get; set; }
        public DbSet<InvoiceGoodsAcceptance> InvoiceGoodsAcceptances { get; set; }
        public DbSet<PersonelAuthority> PersonelAuthorities { get; set; }
        public DbSet<PersonelDocument> PersonelDocuments { get; set; }
        public DbSet<PersonelInterDoc> PersonelInterDocs { get; set; }
        public DbSet<PersAddDoc> PersAddDocs { get; set; }
        public DbSet<BetonKontrolFormuSub> BetonKontrolFormuSub { get; set; }
        public DbSet<BetonKontrolFormuSorulari> BetonKontrolFormuSorulari { get; set; }
        public DbSet<BetonKontrolFormuCevaplari> BetonKontrolFormuCevaplari { get; set; }
        public DbSet<SalesOffer> SalesOffers { get; set; }
        public DbSet<SalesDetailOffer> SalesDetailOffers { get; set; }
        public DbSet<SalesBaseOffer> SalesBaseOffers { get; set; }
        public DbSet<ConcreteRequest> ConcreteRequests { get; set; }
        public DbSet<ProductStepNotif> ProductStepNotifs { get; set; }
        public DbSet<CustomerInteractionOffer> CustomerInteractionOffers { get; set; }
        public DbSet<LastActivity> LastActivitys { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<TaskLog> TaskLog { get; set; }
        public DbSet<TaskMessage> TaskMessage { get; set; }
        public DbSet<PmCalculateDocuments> PmCalculateDocuments { get; set; }
        public DbSet<LogKayit> LogKayits { get; set; }
        public DbSet<UserEmail> UserEmail { get; set; }
        public DbSet<FileProjeModul> FileProjeModul { get; set; }
        public DbSet<MessageModule> MessageModule { get; set; }
        public DbSet<UretimOnayLog> UretimOnayLog { get; set; }
        public DbSet<HolNesne> HolNesne { get; set; }
        public DbSet<LabaratuarSonuc> LabaratuarSonuc { get; set; }
        public DbSet<PersonIstenCikar> PersonIstenCikar { get; set; }
        public DbSet<ISGSafetyIssue> ISGSafetyIssue { get; set; }
        public DbSet<ISGSafetyIssueCategory> ISGSafetyIssueCategory { get; set; }
        public DbSet<ISGSafetyIssueImages> ISGSafetyIssueImages { get; set; }
        public DbSet<ISGSafetyIssueSubCategory> ISGSafetyIssueSubCategory { get; set; }
        public DbSet<VehicleWash> VehicleWash { get; set; }
        public DbSet<VehicleWashImage> VehicleWashImages { get; set; }
        public DbSet<ProjeDonatiRaporu> ProjeDonatiRaporu { get; set; }
        public DbSet<KaliteBirimAtama> KaliteBirimAtama { get; set; }
        public DbSet<KaliteBirimAtamaIlkKontrolUser> KaliteBirimAtamaIlkKontrolUser { get; set; }
        public DbSet<KaliteBirimAtamaSonKontrolUser> KaliteBirimAtamaSonKontrolUser { get; set; }
        public DbSet<VehicleKilometerUpdate> VehicleKilometerUpdate { get; set; }
        public DbSet<VehicleLend> VehicleLend { get; set; }
        public DbSet<SayimDetay> SayimDetay { get; set; }
        public DbSet<SubSayim> SubSayim { get; set; }
        public DbSet<RopeIronPm> RopeIronPm { get; set; }
        public DbSet<StockImage> StockImage { get; set; }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedTime = DateTime.Now;
        //                break;

        //            case EntityState.Modified:

        //                entry.Entity.UpdateTime = DateTime.Now;
        //                break;
        //            default: break;
        //        }
        //    }
        //    return base.SaveChanges();
        //}
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedTime = DateTime.Now;
        //                break;

        //            case EntityState.Modified:

        //                entry.Entity.UpdateTime = DateTime.Now;
        //                break;
        //            default: break;
        //        }
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}