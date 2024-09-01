using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class FuelTransferService : BaseRepository<FuelTransfer>, IFuelTransferService
    {
        public FuelTransferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IEnumerable<FuelTransfer> GetIncludeFuelTransfer()
        {
            var fuelTransfer = _context.FuelTransfers.Include(c => c.Vehicle).ToList();
            return fuelTransfer;
        }

        public Person GetMainResponsibleByPlate(int id)
        {
            var mainResponsible = _context.Vehicles.Where(x => x.Id == id).Include(x => x.MainResponsible).FirstOrDefault();
            return mainResponsible.MainResponsible;
        }
        public void UpdateStockByFuelTransfer(int stockId, decimal amount)
        {
            var stock = _context.Stocks.Where(x => x.Id == stockId).FirstOrDefault();
            stock.Quantity -= Convert.ToDouble(amount);
            _context.Stocks.Update(stock);
            _context.SaveChanges();
        }

        public List<Stock> GetAllStockNamesByCategoryName()
        {
            return _context.Stocks
                .Include(s => s.StockCategory)
                .Where(s => s.StockCategory.Name == "Akaryakıt").ToList();
        }

    }
}
