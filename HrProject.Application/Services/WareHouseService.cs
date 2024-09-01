using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class WareHouseService : BaseRepository<WareHouse>, IWareHouseService
    {
        public WareHouseService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void DepoSil(int id)
        {
            var depo = _context.WareHouses.FirstOrDefault(h => h.Id == id);

            if (depo != null)
            {
                _context.WareHouses.Remove(depo);

                // İlgili stok değişikliklerini de kaldırmak için aşağıdaki satırı ekleyebiliriz.
                var relatedStockChanges = _context.StockChanges
                    .Where(x => x.EntryWareHouseId == id || x.ExitWareHouseId == id)
                    .ToList();
                _context.StockChanges.RemoveRange(relatedStockChanges);

                var relatedStockChanges2 = _context.StockMoves
                   .Where(x => x.WareHouseId == id)
                   .ToList();
                _context.StockMoves.RemoveRange(relatedStockChanges2);

                var relatedStockChanges4 = _context.InWaybillChanges
                   .Where(x => x.WareHouseId == id)
                   .ToList();
                _context.InWaybillChanges.RemoveRange(relatedStockChanges4);
                var relatedStockChanges5 = _context.OutWaybillChanges
                   .Where(x => x.WareHouseId == id)
                   .ToList();
                _context.OutWaybillChanges.RemoveRange(relatedStockChanges5);

                var relatedStockChanges3 = _context.StockSub
                 .Where(x => x.EntryWareHouseId == id || x.ExitWareHouseId == id)
                 .ToList();
                _context.StockSub.RemoveRange(relatedStockChanges3);
                _context.SaveChanges();
            }
        }

        public bool ExistsByProperty(string code)
        {
            return _context.WareHouses.Any(w => w.Code == code);
        }

        //public bool ExistsByCode(string code)
        //{

        //    return _context.WareHouses.Any(w => w.Code == code);
        //}
    }
}
