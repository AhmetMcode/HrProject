using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class MaintenanceRequestService : BaseRepository<MaintenanceRequest>, IMaintenanceRequestService
    {
        public MaintenanceRequestService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public MaintenanceRequest GetByIdInclude(int id)
        {
            var maintenanceRequest = _context.MaintenanceRequests.Include(c => c.Vehicle).Include(x => x.MaintenanceRequestListServices)
                .Where(x => x.Id == id).FirstOrDefault();
            return maintenanceRequest;
        }

        public IEnumerable<MaintenanceRequest> GetIncludeMaintenanceRequest()
        {
            var maintenanceRequest = _context.MaintenanceRequests.Include(c => c.Vehicle).ToList();
            return maintenanceRequest;
        }
    }
}
