using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ConcreteRequestService : BaseRepository<ConcreteRequest>, IConcreteRequest
    {
        public ConcreteRequestService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<ConcreteRequest> GetConcreteRequestByPlaceIdInclude(int id)
        {
            return _context.ConcreteRequests.Where(x => x.ProductionPlaceId == id).Include(x => x.ActionUser).Include(x => x.RequestUser).Include(x => x.ConcreteClass).Include(x => x.ProductManifact2s).ThenInclude(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned).ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan).ToList();
        }
    }
}
