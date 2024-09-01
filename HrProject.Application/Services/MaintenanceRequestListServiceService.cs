using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class MaintenanceRequestListServiceService : BaseRepository<MaintenanceRequestListService>, IMaintenanceRequestListServiceService
    {
        public MaintenanceRequestListServiceService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public IEnumerable<MaintenanceRequestListService> GetIncludeMaintenanceRequests()
        {
            var maintenance = _context.MaintenanceRequestListServices.Include(c => c.MaintenanceService).ToList();
            return maintenance;
        }

        public IEnumerable<MaintenanceRequestListService> GetIncludeMaintenanceRequestsByRequesId(int requestId)
        {
            var maintenance = _context.MaintenanceRequestListServices.Where(x => x.MaintenanceRequestId == requestId)
                .Include(c => c.MaintenanceService)
                .ThenInclude(x => x.MaintenancesStocks)
                .ToList();
            return maintenance;
        }
    }
}
