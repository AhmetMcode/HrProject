using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IGoodsCodeService : IBaseRepository<GoodsCode>
    {
        public string GetStocksNameWithGoodsCodeId(int id);
        public IEnumerable<Stock> GetStockWithGoodsCodeId(int id);
    }
}
