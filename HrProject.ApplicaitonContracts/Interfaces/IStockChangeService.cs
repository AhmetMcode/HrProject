using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IStockChangeService : IBaseRepository<StockChange>
    {
        public IEnumerable<StockChange> GetIncludeStockChanges();
        public void UpdateChangesByQuant(StockChange stockChange);
        public Task AddStockSub(StockSub stockSub);
        public List<StockSub> GetIncludeStockChangesSub();
        public StockSub GetSubById(int id);
        public decimal GetByQuantityWareHouseAndStockId(int stockId, int wareHouseId);
        public decimal GetByQuantityStockId(int stockId);
        public List<StockChange> GetByChangesByStockId(int stockId);


    }
}
