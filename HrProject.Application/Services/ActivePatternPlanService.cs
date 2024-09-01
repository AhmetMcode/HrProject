using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ActivePatternPlanService : BaseRepository<ActivePatternPlan>, IActivePatternPlan
    {
        public ActivePatternPlanService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<ActivePatternPlan> GetActivePatternPlansByIdInclude(int id)
        {
            return _context.ActivePatternPlan.Where(x => x.ProductionPlaceId == id).Include(x => x.Pattern).Include(x => x.ProductionPlace).ToList();
        }

        public List<ActivePatternPlan> GetAllInclude()
        {
            return _context.ActivePatternPlan.Include(x => x.Pattern).Include(x => x.ProductionPlace).ToList();
        }

        public List<ProductPlan> GetAllPlans()
        {
            return _context.ProductPlan
                   .Include(x => x.ProductPlanSubPlanned)
                       .ThenInclude(x => x.PmCalculate).ThenInclude(x => x.ConcreteClass)
                   .Include(x => x.ProductPlanSubPlanned)
                       .ThenInclude(x => x.PmCalculate)
                               .ThenInclude(x => x.ProjectElementType).ThenInclude(x => x.ProjectElement)
                   .Include(x => x.ProductPlanSubPlanned)
                       .ThenInclude(x => x.ProductPlanDailyPlanned)
                           .ThenInclude(x => x.ProductPlanProductPlanned)
                   .ToList();

        }

        public DateTime GetAviablePatternDate(int patternId)
        {
            var pattern = _context.ActivePatternPlan.FirstOrDefault(x => x.Id == patternId);

            if (pattern != null)
            {
                var plans = _context.ProductPlanSubPlanned
                    .Where(x => x.PatternId == patternId).Where(X => X.TerminType != TerminType.Dusuk)
                    .Include(x => x.ProductPlanDailyPlanned)
                        .ThenInclude(x => x.ProductPlanProductPlanned)
                    .ToList();

                var products = plans
                    .SelectMany(plan => plan.ProductPlanDailyPlanned
                        .SelectMany(dailyPlan => dailyPlan.ProductPlanProductPlanned))
                    .ToList();

                if (products.Any())
                {
                    var maxEndTime = products.Max(x => x.EndTime);
                    return maxEndTime.AddDays(2);
                }
            }

            return DateTime.Now; // veya başka bir değer
        }

        public ProductPlan GetByOfferId(int id)
        {
            return _context.ProductPlan
                   .Where(x => x.OfferId == id)
                   .Include(x => x.ProductPlanSubPlanned)
                       .ThenInclude(x => x.OfferCalculate).ThenInclude(x => x.ConcreteClass)
                   .Include(x => x.ProductPlanSubPlanned)
                       .ThenInclude(x => x.OfferCalculate)
                               .ThenInclude(x => x.ProjectElementType).ThenInclude(x => x.ProjectElement)
                   .Include(x => x.ProductPlanSubPlanned)
                       .ThenInclude(x => x.ProductPlanDailyPlanned)
                           .ThenInclude(x => x.ProductPlanProductPlanned)
                   .FirstOrDefault();
        }

        public ProductPlan GetByProjectId(int id)
        {
            return _context.ProductPlan
                    .Where(x => x.ProjectModuleSubId == id)
                    .Include(x => x.ProductPlanSubPlanned)
                        .ThenInclude(x => x.PmCalculate).ThenInclude(x => x.ConcreteClass)
                    .Include(x => x.ProductPlanSubPlanned)
                        .ThenInclude(x => x.PmCalculate)
                                .ThenInclude(x => x.ProjectElementType).ThenInclude(x => x.ProjectElement)
                    .Include(x => x.ProductPlanSubPlanned)
                        .ThenInclude(x => x.ProductPlanDailyPlanned)
                            .ThenInclude(x => x.ProductPlanProductPlanned)
                    .FirstOrDefault();


        }

        public void UpdateTerminSubOnlyPlan(OfferTerminSub offerTerminSub)
        {
            var offerTermin = _context.OfferTerminSub.Where(x => x.Id == offerTerminSub.Id).FirstOrDefault();
            offerTermin.AnsWer = offerTerminSub.AnsWer;
            _context.OfferTerminSub.Update(offerTermin);
            foreach (var item in offerTerminSub.OfferTerminDetails)
            {
                var detail = _context.OfferTerminDetail.Where(x => x.Id == item.Id).FirstOrDefault();
                detail.BitisTarihi = item.BitisTarihi;
                _context.OfferTerminDetail.Update(detail);
            }
            _context.SaveChanges();
        }
    }
}
