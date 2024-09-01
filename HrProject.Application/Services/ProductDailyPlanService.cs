using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProductDailyPlanService : BaseRepository<ProductPlanDailyPlanned>, IProductDailyPlanService
    {
        public ProductDailyPlanService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<ProductPlanDailyPlanned> BuKaliptakiSon2UretimEmri(int patternId)
        {
            return _context.ProductPlanDailyPlanned.Include(x => x.ProductPlanProductPlanned).Include(x => x.ProductPlanSubPlanned)
        .Where(x => x.ProductPlanSubPlanned.PatternId == patternId)
        .OrderByDescending(x => x.StartTime)
        .Take(2)
        .ToList();
        }

        public ProductPlanDailyPlanned BuKaliptakiSonUretilmeyen(int patternId)
        {
            return _context.ProductPlanDailyPlanned.Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductManifact2).ThenInclude(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType).Include(x => x.ProductPlanSubPlanned)
                    .Where(x => x.ProductPlanSubPlanned.PatternId == patternId).Where(x => x.Actual == false)
                    .FirstOrDefault();
        }

        public List<ProductPlanDailyPlanned> GetByKalipId(int patternId, DateTime baslangic, DateTime bitis)
        {
            var plans = _context.ProductPlanDailyPlanned.Where(x => x.StartTime.Date >= baslangic && x.EndTime.Date <= bitis.Date).Include(x => x.ProductPlanProductPlanned).Include(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan)
        .Where(x => x.ProductPlanSubPlanned.PatternId == patternId)
        .OrderByDescending(x => x.StartTime)
        .ToList();
            foreach (var item in plans)
            {
                item.ProductPlanSubPlanned.ProductPlanDailyPlanned = null;
            }
            return plans;
        }
    }
}
