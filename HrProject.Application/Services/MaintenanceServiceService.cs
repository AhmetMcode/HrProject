using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class MaintenanceServiceService : BaseRepository<MaintenanceService>, IMaintenanceServiceService
    {
        public MaintenanceServiceService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public MaintenanceService GetByIdInclude(int id)
        {
            var maintenanceService = _context.MaintenanceServices.Include(c => c.Vehicle).Include(x => x.MaintenancesStocks)
                .Where(x => x.Id == id).FirstOrDefault();
            return maintenanceService;
        }
        public IEnumerable<MaintenanceService> GetIncludeMaintenanceService()
        {
            var maintenanceService = _context.MaintenanceServices.Include(c => c.Vehicle).Include(c => c.MaintenancesStocks).ToList();
            return maintenanceService;
        }
        public string GetCategoryByPlate(int id)
        {
            var Vcategory = _context.Vehicles.Where(x => x.Id == id).Include(x => x.VehicleCategory).FirstOrDefault();
            return Vcategory.VehicleCategory.Name;
        }

    }
}
