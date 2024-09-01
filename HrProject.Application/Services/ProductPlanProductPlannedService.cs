using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Application.Services
{
    public class ProductPlanProductPlannedService : BaseRepository<ProductPlanProductPlanned>, IProductPlanProductPlannedService
    {
        public ProductPlanProductPlannedService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<ProductPlanProductPlanned> TariheGoreUrunler(DateTime tarih)
        {
            List<ProductPlanProductPlanned> productPlanProductPlanneds = new List<ProductPlanProductPlanned>();
            productPlanProductPlanneds = _context.ProductPlanProductPlanned.Include(x => x.ProductPlanDailyPlanned).ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.Pattern).Where(x => x.ProductPlanDailyPlanned.StartTime.Date == tarih.Date).ToList();
            foreach (var item in productPlanProductPlanneds)
            {
                item.ProductPlanDailyPlanned.ProductPlanProductPlanned = null;
                item.ProductPlanDailyPlanned.ProductPlanSubPlanned.ProductPlanDailyPlanned = null;
            }
            return productPlanProductPlanneds;
        }
    }
}
