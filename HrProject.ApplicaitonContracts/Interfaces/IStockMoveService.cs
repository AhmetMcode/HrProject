using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IStockMoveService : IBaseRepository<StockMove>
    {
        public IEnumerable<StockMove> GetIncludeStockMoves();
    }
}
