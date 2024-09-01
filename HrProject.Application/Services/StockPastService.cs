using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class StockPastService : BaseRepository<StockPast>, IStockPastService
    {
        public StockPastService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public IEnumerable<StockPast> GetIncludeOutWaybill()
        {
            var result = _context.StockPasts.Include(x => x.OutWaybill2).ThenInclude(x => x.CariKart).Include(x => x.OutWaybill2).ThenInclude(x => x.OutWaybillChanges).ThenInclude(x => x.Stock);

            return result;
        }

    }
}
