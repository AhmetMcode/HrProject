using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System.Text;

namespace HrProject.Application.Services
{
    public class StockService : BaseRepository<Stock>, IStockService
    {
        public StockService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public void AddStock(Stock stock)
        {
            var category = _context.StockCategories.Where(c => c.Id == stock.StockCategoryId).FirstOrDefault();
            stock.Code = category.Code + _context.Stocks.Where(x => x.StockCategoryId == stock.StockCategoryId).Count().ToString("00000");
            Insert(stock);
        }


        public IEnumerable<Stock> GetIncludeStocks()
        {
            var result = _context.Stocks.Include(x => x.StockCategory)
                                        .Include(x => x.Unit).Include(x => x.PurchaseVat).Include(x => x.SaleVat).Include(x => x.BuyingWithholdingRate).Include(x => x.BuyingWithholdingType).Include(x => x.SalesWithholdingRate).Include(x => x.SalesWithholdingType).Include(x => x.EDocumentBaseRate).Include(x => x.GoodsCode);
            return result;
        }

        public PurchaseVat GetVatByStockId(int id)
        {
            var vat = _context.Stocks.Where(x => x.Id == id).Include(x => x.PurchaseVat).FirstOrDefault().PurchaseVat;
            return vat;
        }

        public Unit GetUnitTypeByStockId(int id)
        {
            var unittype = _context.Stocks
                .Where(x => x.Id == id)
                .Include(x => x.Unit)
                .FirstOrDefault();

            return unittype.Unit; // Unit null olabilir, bu durumu kontrol et
        }




        public List<StockChange> GetStocksMove(int WareHouseId, int GoodsCodeId, int stockId, DateTime entry, DateTime exit)
        {
            var stockChanges = new List<StockChange>();
            if (GoodsCodeId == 0)
            {
                stockChanges = _context.StockChanges
                .Include(x => x.Stock) // Stock tablosunu Include et
                //.Include(x => x.GoodsCode) // GoodsCode tablosunu Include et
                .Include(x => x.EntryWareHouse) // EntryWareHouse tablosunu Include et
                .Include(x => x.ExitWareHouse) // ExitWareHouse tablosunu Include et
                .Where(x =>
                    (x.EntryWareHouseId == WareHouseId || x.ExitWareHouseId == WareHouseId) &&
                    x.CreatedTime.HasValue &&
                    x.CreatedTime.Value.Date >= entry.Date &&
                    x.CreatedTime.Value.Date <= exit.Date)
                .ToList();
            }
            else
            {
                if (stockId != 0)
                {
                    stockChanges = _context.StockChanges
               .Include(x => x.Stock) // Stock tablosunu Include et
                                      //.Include(x => x.GoodsCode) // GoodsCode tablosunu Include et
               .Include(x => x.EntryWareHouse) // EntryWareHouse tablosunu Include et
               .Include(x => x.ExitWareHouse) // ExitWareHouse tablosunu Include et
               .Where(x =>
                   (x.EntryWareHouseId == WareHouseId || x.ExitWareHouseId == WareHouseId) &&
                   x.StockId == stockId &&
                   x.CreatedTime.HasValue &&
                   x.CreatedTime.Value.Date >= entry.Date &&
                   x.CreatedTime.Value.Date <= exit.Date)
               .ToList();
                }
                else
                {
                    stockChanges = _context.StockChanges
               .Include(x => x.Stock) // Stock tablosunu Include et
                                      //.Include(x => x.GoodsCode) // GoodsCode tablosunu Include et
               .Include(x => x.EntryWareHouse) // EntryWareHouse tablosunu Include et
               .Include(x => x.ExitWareHouse) // ExitWareHouse tablosunu Include et
               .Where(x =>
                   (x.EntryWareHouseId == WareHouseId || x.ExitWareHouseId == WareHouseId) &&
                   x.Stock.GoodsCodeId == GoodsCodeId &&
                   x.CreatedTime.HasValue &&
                   x.CreatedTime.Value.Date >= entry.Date &&
                   x.CreatedTime.Value.Date <= exit.Date)
               .ToList();
                }
            }


            return stockChanges;
        }

        public string GetBarkodByStokAdi(int id)
        {
            // Stok özelinde barkod getirme işlemi
            var stok = _context.Stocks.Where(x => x.Id == id).FirstOrDefault();

            // Özel iş mantığına göre barkodu alabilirsiniz
            return stok?.Barcode;
        }

        public string GenerateUniqueBarcode()
        {

            var existingBarcodes = _context.Stocks.Select(x => x.Barcode).ToList();

            string newBarcode;

            do
            {
                const int barcodeLength = 11;
                var random = new Random();
                var barcode = new char[barcodeLength];

                // Rastgele bir 13 haneli sayı üret
                for (int i = 0; i < barcodeLength; i++)
                {
                    barcode[i] = (char)('0' + random.Next(10));
                }

                newBarcode = "12" + new string(barcode);
            } while (existingBarcodes.Contains(newBarcode));

            return newBarcode;
        }

        public string GenerateRandomBarcode()
        {
            const int barcodeLength = 13;
            var random = new Random();
            var barcode = new char[barcodeLength];

            for (int i = 0; i < barcodeLength; i++)
            {
                barcode[i] = (char)('0' + random.Next(10));
            }

            return new string(barcode);
        }

        public string ConvertTurkishToEnglish(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            Dictionary<char, string> turkishToEnglish = new Dictionary<char, string>
    {
        {'ı', "i"},
        {'ğ', "g"},
        {'ü', "u"},
        {'ş', "s"},
        {'ö', "o"},
        {'ç', "c"},
        {'İ', "I"},
        {'Ğ', "G"},
        {'Ü', "U"},
        {'Ş', "S"},
        {'Ö', "O"},
        {'Ç', "C"}
    };

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (turkishToEnglish.ContainsKey(c))
                {
                    result.Append(turkishToEnglish[c]);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public List<StockUnit> GetByStockIdStockUnits(int id)
        {
            var stockUnits = _context.StockUnits.Where(x => x.StockId == id).Include(x => x.Stock).Include(x => x.Unit).ToList();
            return stockUnits;
        }

        public void AddStockUnit(int stockId, int unitId, decimal carpan, bool isDefault)
        {
            StockUnit stockUnit = new StockUnit();
            stockUnit.StockId = stockId;
            stockUnit.UnitId = unitId;
            stockUnit.Carpan = carpan;
            stockUnit.IsDefault = isDefault;
            _context.StockUnits.Add(stockUnit);
            _context.SaveChanges();
        }

        public void UpdateStockUnit(int stockId, int unitId, decimal carpan, bool isDefault)
        {
            var stockUnit = _context.StockUnits.Where(x => x.UnitId == unitId && x.StockId == stockId).FirstOrDefault();
            if (stockUnit == null)
            {

            }
            else
            {
                stockUnit.Carpan = carpan;
                _context.StockUnits.Update(stockUnit);
                _context.SaveChanges();

            }
        }

        public List<Unit> GetUnitsByStock(int id)
        {
            var stock = _context.Stocks.Where(x => x.Id == id).Include(x => x.Unit).FirstOrDefault();
            var units = new List<Unit>();
            units.Add(stock.Unit);
            var unitsss = _context.StockUnits.Where(x => x.StockId == stock.Id).Include(x => x.Unit).ToList().Select(x => x.Unit).ToList();
            if (unitsss != null)
            {
                units.AddRange(unitsss);
            }
            return units;
        }

        public List<Unit> GetByUnitsByStockId(int stockId)
        {
            var stock = _context.Stocks.Where(x => x.Id == stockId).Include(x => x.Unit).FirstOrDefault();
            var otherStocks = _context.StockUnits.Where(x => x.StockId == stockId).Include(x => x.Unit).ToList().Select(x => x.Unit).ToList();
            if (otherStocks == null)
            {
                List<Unit> units = new List<Unit>();
                units.Add(stock.Unit);
                return units;
            }
            otherStocks.Add(stock.Unit);
            return otherStocks;
        }

        public Stock GetIncludeById(int id)
        {
            return _context.Stocks.Where(x => x.Id == id).Include(x => x.StockCategory)
                                        .Include(x => x.Unit).Include(x => x.PurchaseVat).Include(x => x.SaleVat).Include(x => x.BuyingWithholdingRate).Include(x => x.BuyingWithholdingType).Include(x => x.SalesWithholdingRate).Include(x => x.SalesWithholdingType).Include(x => x.EDocumentBaseRate).Include(x => x.GoodsCode).FirstOrDefault();
        }

    }
}
