using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class StockChangeService : BaseRepository<StockChange>, IStockChangeService
    {
        public StockChangeService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public async Task AddStockSub(StockSub stockSub)
        {
            foreach (var item in stockSub.StockChanges)
            {
                item.StockChangeEnum = stockSub.StockChangeEnum;
                item.DateChange = stockSub.DateChange;
                item.StockSubId = stockSub.Id;
                item.EntryWareHouseId = stockSub.EntryWareHouseId;
                item.ExitWareHouseId = stockSub.ExitWareHouseId;
                if (item.UnitType == null)
                {
                    item.UnitType = "Belirtilmemiş";
                }
                var stock = _context.Stocks.Where(x => x.Id == item.StockId).FirstOrDefault();
                if (stock != null)
                {
                    if (item.StockChangeEnum == Domain.Enums.StockChangeEnum.StokCikis)
                    {
                        stock.Quantity -= ((double)item.Quantity);
                    }
                    if (item.StockChangeEnum == Domain.Enums.StockChangeEnum.StokGiris)
                    {
                        stock.Quantity += ((double)item.Quantity);

                    }
                    _context.Stocks.Update(stock);
                }
            }
            try
            {
                _context.StockSub.Add(stockSub);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<StockChange> GetIncludeStockChanges()
        {
            var result = _context.StockChanges.Include(x => x.Stock).Include(x => x.EntryWareHouse).Include(x => x.ExitWareHouse).Include(x => x.OutWaybill2).ThenInclude(x => x.CariKart).Include(x => x.InWaybill).ThenInclude(x => x.CariKart);
            return result;
        }

        public void UpdateChangesByQuant(StockChange stockChange)
        {
            _context.StockChanges.Add(stockChange);
            _context.SaveChanges();
            var stock = _context.Stocks.Where(x => x.Id == stockChange.StockId).FirstOrDefault();
            if (stock.Quantity == null)
            {
                stock.Quantity = 0;
            }
            stock.Quantity -= Convert.ToDouble(stockChange.Quantity);
            _context.Stocks.Update(stock);
        }
        public List<StockSub> GetIncludeStockChangesSub()
        {
            var sub = _context.StockSub.Include(x => x.EntryWareHouse).Include(x => x.ExitWareHouse).Include(x => x.TeslimAlan).Include(x => x.TeslimEden).Include(x => x.StockChanges).ToList();
            return sub;
        }

        public StockSub GetSubById(int id)
        {
            var sub = _context.StockSub.Where(x => x.Id == id).Include(x => x.EntryWareHouse).Include(x => x.ExitWareHouse).Include(x => x.TeslimAlan).Include(x => x.TeslimEden).Include(x => x.StockChanges).FirstOrDefault();
            return sub;
        }

        public decimal GetByQuantityWareHouseAndStockId(int stockId, int wareHouseId)
        {
            var pozitifChanges = _context.StockChanges.Where(x => x.StockId == stockId).Where(x => x.EntryWareHouseId == wareHouseId).Include(x => x.Stock).ThenInclude(x => x.Unit).ToList().Sum(x => x.Quantity);
            var negatifChanges = _context.StockChanges.Where(x => x.StockId == stockId).Where(x => x.ExitWareHouseId == wareHouseId).Include(x => x.Stock).ThenInclude(x => x.Unit).ToList().Sum(x => x.Quantity);
            return pozitifChanges - negatifChanges;

        }

        public decimal GetByQuantityStockId(int stockId)
        {
            var stockChanges = _context.StockChanges.Where(x => x.StockId == stockId).Include(x => x.Stock).ThenInclude(x => x.Unit).ToList();
            return stockChanges.Sum(x => x.Quantity);
        }
        public List<StockChange> GetByChangesByStockId(int stockId)
        {
            var stockChanges = _context.StockChanges.Where(x => x.StockId == stockId).Include(x => x.Stock).ThenInclude(x => x.Unit).Include(x => x.EntryWareHouse).Include(x => x.ExitWareHouse).ToList();
            return stockChanges;
        }


    }
}
