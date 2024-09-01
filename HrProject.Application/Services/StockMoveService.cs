using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class StockMoveService : BaseRepository<StockMove>, IStockMoveService
    {
        public StockMoveService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public IEnumerable<StockMove> GetIncludeStockMoves()
        {
            var result = _context.StockMoves.Include(x => x.WareHouse).Include(x => x.GoodsCode);
            return result;
        }
    }

}
