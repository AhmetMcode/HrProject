using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProductStepNotifService : BaseRepository<ProductStepNotif>, IProductStepNotifService
    {
        public ProductStepNotifService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<ProductStepNotif> GetByStepIdInclude(int id)
        {
            return _context.ProductStepNotifs.Where(x => x.ProductionStepId == id).Include(x => x.ProductionStep).Include(x => x.IdentityRole).ToList();
        }
    }
}
