using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IStockService : IBaseRepository<Stock>
    {
        //IEnumerable<object> Stocks { get; set; }

        void AddStock(Stock stock);
        public void AddStockUnit(int stockId, int unitId, decimal carpan, bool isDefault);
        public void UpdateStockUnit(int stockId, int unitId, decimal carpan, bool isDefault);
        IEnumerable<Stock> GetIncludeStocks();
        public Stock GetIncludeById(int id);
        public List<StockUnit> GetByStockIdStockUnits(int id);
        public List<Unit> GetUnitsByStock(int id);
        public PurchaseVat GetVatByStockId(int id);
        public Unit GetUnitTypeByStockId(int id);

        public string GetBarkodByStokAdi(int id);
        public List<StockChange> GetStocksMove(int WareHouseId, int GoodsCodeId, int stockId, DateTime entriy, DateTime exit);
        public string GenerateUniqueBarcode();
        public string GenerateRandomBarcode();
        public string ConvertTurkishToEnglish(string input);
        public List<Unit> GetByUnitsByStockId(int stockId);

    }
}
