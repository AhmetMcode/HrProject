using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProductManifactService : BaseRepository<ProductManifact2>, IProductManifact
    {
        public ProductManifactService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ProductManifact2 GetByProductPlanId(int productPlanId)
        {
            var productPlan = _context.ProductManifacts2.Where(x => x.ProductPlanProductPlannedId == productPlanId).Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProductManifactDetailImages).Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned).ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.Pattern).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned).ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan).Include(x => x.ProductManifactDetail).FirstOrDefault();
            return productPlan;

        }

        public List<ProductManifact2> GetIncludeByDateDemir(DateTime dateTime)
        {
            if (dateTime.Date == DateTime.MinValue.Date)
            {
                dateTime = DateTime.Today; // Bugünün tarihini al
            }

            var mcs = _context.ProductManifacts2
     .Where(x =>
                 x.ProductManifactDetail.Any(detail =>
                     detail.ProjectElementStep.ProductionStep.ManifactStepType.Name == "Demir" &&
                     detail.ProductStepEnum == ProductStepDurumEnum.Finish && detail.ProjectElementStep.LastStep == true))
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.Pattern)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.PmCalculate)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.ProductPlan)
     .ToList();
            return mcs;
        }

        public List<ProductManifact2> GetIncludeByDate(DateTime dateTime, int productionPlace)
        {
            if (dateTime.Date == DateTime.MinValue.Date)
            {
                dateTime = DateTime.Today; // Bugünün tarihini al
            }
            if (productionPlace == 0)
            {
                var mcs = _context.ProductManifacts2
                                .Where(x => x.ProductPlanProductPlanned.StartTime.Date == dateTime.Date)
                                .Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep)
                                .ToList();
                return mcs;

            }
            else
            {
                var mcs = _context.ProductManifacts2
                                .Where(x => x.ProductPlanProductPlanned.StartTime.Date == dateTime.Date && x.IronProductionPlaceId == productionPlace)
                                .Include(x => x.ProductPlanProductPlanned)
                                .ThenInclude(x => x.ProductPlanDailyPlanned)
                                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.Pattern)
                                .Include(x => x.ProductPlanProductPlanned)
                                .ThenInclude(x => x.ProductPlanDailyPlanned)
                                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.PmCalculate)
                                .Include(x => x.ProductPlanProductPlanned)
                                .ThenInclude(x => x.ProductPlanDailyPlanned)
                                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan)
                                .ToList();
                return mcs;
            }
            // Belirli bir tarihle ilişkilendirilmiş ProductManifact2 öğelerini al


        }

        public List<ProductManifact2> GetIncludeByOld()
        {
            var mcs = _context.ProductManifacts2
                                .Where(x => x.ProductPlanProductPlanned.StartTime.Date < DateTime.Now.AddDays(-1).Date)
                                .Include(x => x.ProductPlanProductPlanned)
                                .ThenInclude(x => x.ProductPlanDailyPlanned)
                                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.Pattern)
                                .Include(x => x.ProductPlanProductPlanned)
                                .ThenInclude(x => x.ProductPlanDailyPlanned)
                                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.PmCalculate)
                                .Include(x => x.ProductPlanProductPlanned)
                                .ThenInclude(x => x.ProductPlanDailyPlanned)
                                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan)
                                .ToList();
            return mcs;
        }

        public List<ProductManifact2> GetlAllManifactsPmCalculateIds(List<int> pmCalculateIds)
        {
            var mcs = _context.ProductManifacts2
                                .Include(x => x.ProductPlanProductPlanned)
                                    .ThenInclude(x => x.ProductPlanDailyPlanned)
                                        .ThenInclude(x => x.ProductPlanSubPlanned)
                                            .ThenInclude(x => x.Pattern)
                                .Include(x => x.ProductPlanProductPlanned)
                                    .ThenInclude(x => x.ProductPlanDailyPlanned)
                                        .ThenInclude(x => x.ProductPlanSubPlanned)
                                            .ThenInclude(x => x.PmCalculate)
                                .Include(x => x.ProductPlanProductPlanned)
                                    .ThenInclude(x => x.ProductPlanDailyPlanned)
                                        .ThenInclude(x => x.ProductPlanSubPlanned)
                                            .ThenInclude(x => x.ProductPlan)
                                            .Include(x => x.ProductManifactDetail)
                                            .ThenInclude(x => x.ProjectElementStep)
                                            .ThenInclude(x => x.ProductionStep)
                                .Where(x => pmCalculateIds.Contains((int)x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.PmCalculateId))
                                .ToList(); // İkinci ToList() çağrısı gerekebilir, çünkü Where'den sonra IEnumerable dönebilirsiniz.
            return mcs;
        }



        public List<ManifactStepType> GetlAllManifactStepType()
        {
            return _context.ManifactStepTypes.ToList();
        }

        public async Task<List<ProductManifact2>> Start(List<ProductManifact2> productManifact)
        {
            return productManifact;
        }


        async Task IProductManifact.Ekle(List<ProductManifact2> productManifact)
        {
            try
            {
                foreach (var item in productManifact)
                {
                    item.ProductPlanProductPlanned = null;
                }
                _context.ProductManifacts2.AddRangeAsync(productManifact);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.ToString());
            }


        }

        async Task IProductManifact.Start(List<ProductManifact2> productManifact)
        {
            try
            {
                foreach (var item in productManifact)
                {
                    var pfm = _context.ProductManifacts2.Where(x => x.Id == item.Id).FirstOrDefault();
                    pfm.ManifactDesc = item.ManifactDesc;
                    pfm.ConcreteProductionPlaceId = item.ConcreteProductionPlaceId;
                    pfm.IronProductionPlaceId = (int)item.IronProductionPlaceId;
                    _context.ProductManifacts2.Update(pfm);
                    var productManifactDetail = _context.ProductManifactDetails
                                .Where(x => x.ProductManifact.Id == item.Id) // Belirli ProductManifact ID'sine sahip girdileri seç
                                .OrderBy(x => x.ProjectElementStep.Sequence) // Sequence'e göre artan şekilde sırala
                                .FirstOrDefault();
                    productManifactDetail.ProductStepEnum = ProductStepDurumEnum.Start;
                    _context.ProductManifactDetails.Update(productManifactDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                await Console.Out.WriteLineAsync(e.ToString());
            }
        }

        public List<ProductManifact2> GetIncludeByDateBeton(DateTime dateTime)
        {
            if (dateTime.Date == DateTime.MinValue.Date)
            {
                dateTime = DateTime.Today; // Bugünün tarihini al
            }

            var mcs = _context.ProductManifacts2
                .Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.Pattern)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.PmCalculate)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.ProductPlan)
                .Where(x => x.ProductPlanProductPlanned.StartTime.Date == dateTime.Date)
     .ToList();
            return mcs;
        }

        public List<ProductManifact2> GetByProjectId(int id)
        {
            var maniacts = _context.ProductManifacts2.Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.Pattern)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.PmCalculate)
     .Include(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned)
         .ThenInclude(x => x.ProductPlanSubPlanned)
             .ThenInclude(x => x.ProductPlan).Where(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.ProductPlan.ProjectModuleSubId == id).ToList();
            return maniacts;

        }

        public ProductManifact2 OnlyManifactGetByProductPlanId(int productPlanId)
        {
            var uretimEmri = _context.ProductManifacts2.Where(x => x.ProductPlanProductPlannedId == productPlanId).Include(x => x.ProductManifactDetail).FirstOrDefault();
            return uretimEmri;
        }

        public List<ProductManifact2> UruneGoreGetir(int[] idler)
        {
            var uretimEmri = _context.ProductManifacts2.Where(x => idler.Contains(x.ProductPlanProductPlannedId)).Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType).ToList();
            return uretimEmri;

        }

        public List<ProductManifact2> GunPlanaGoreUretimDetaylar(ProductPlanDailyPlanned productPlanDailyPlanneds)
        {
            var productPlanProductPlannedIds = productPlanDailyPlanneds
       .ProductPlanProductPlanned
       .Select(product => product.Id)
       .ToList();

            var manifs = _context.ProductManifacts2
                .Where(x => productPlanProductPlannedIds.Contains(x.ProductPlanProductPlannedId))
                .Include(x => x.ProductManifactDetail)
                    .ThenInclude(x => x.ProjectElementStep)
                        .ThenInclude(x => x.ProductionStep)
                            .ThenInclude(x => x.ManifactStepType)
                .ToList();

            return manifs;
        }

        public async Task StartManifactDetail(int detailId)
        {
            var detail = await _context.ProductManifactDetails.FirstOrDefaultAsync(x => x.Id == detailId);
            if (detail != null)
            {
                detail.IsActive = true;
                detail.StartDate = DateTime.Now;
                _context.ProductManifactDetails.Update(detail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EndManifactDetail(int detailId)
        {
            var detail = await _context.ProductManifactDetails.FirstOrDefaultAsync(x => x.Id == detailId);
            if (detail != null)
            {
                detail.IsActive = false;
                detail.EndDate = DateTime.Now;
                _context.ProductManifactDetails.Update(detail);
                await _context.SaveChangesAsync();
            }
        }

    }
}
