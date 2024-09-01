using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class MaintenancesStockService : BaseRepository<MaintenancesStock>, IMaintenancesStockService
    {
        public MaintenancesStockService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public IEnumerable<MaintenancesStock> GetIncludeMaintenancesStock()
        {
            var maintenancestokService = _context.MaintenancesStocks.Include(c => c.Stock).Include(c => c.Unit).ToList();
            return maintenancestokService;
        }


    }
}
