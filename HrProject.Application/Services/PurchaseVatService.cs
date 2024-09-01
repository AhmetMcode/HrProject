using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PurchaseVatService : BaseRepository<PurchaseVat>, IPurchaseVatService
    {
        public PurchaseVatService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public IEnumerable<PurchaseVat> GetIncludeStocks()
        //{
        //    var result = _context.PurchaseVats.Include(x => x.VATRateCode);

        //    return result;
        //}

    }
}
