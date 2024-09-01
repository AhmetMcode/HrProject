using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProductPlanSubPlannedService : BaseRepository<ProductPlanSubPlanned>, IProductPlanSubPlanned
    {
        public ProductPlanSubPlannedService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<ProductPlan> GetAllProductPlan()
        {
            return _context.ProductPlan.ToList();
        }

        public List<ProductPlanProductPlanned> GetProductPlanPlannedByProjectId(int projectId)
        {
            var pmCalculates = _context.PmCalculates.Where(x => x.ProjectModuleSubId == projectId).ToList().Select(x => x.Id).ToList();
            var dailys = _context.ProductPlanProductPlanned
                      .Include(x => x.ProductPlanDailyPlanned).ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan)
                      .Where(x => pmCalculates.Contains((int)x.ProductPlanDailyPlanned.ProductPlanSubPlanned.PmCalculateId)).ToList();
            return dailys;

        }
    }
}
