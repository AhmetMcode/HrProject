using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class GoodsCodeService : BaseRepository<GoodsCode>, IGoodsCodeService
    {
        public GoodsCodeService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public string GetStocksNameWithGoodsCodeId(int id)
        {
            var stoks = _context.Stocks.Where(x => x.GoodsCodeId == id).ToList().Select(x => x.Name);
            return string.Join(" - ", stoks);

        }

        public IEnumerable<Stock> GetStockWithGoodsCodeId(int id)
        {
            var stoks = _context.Stocks.Where(x => x.GoodsCodeId == id).ToList();

            return stoks;
        }
    }
}
