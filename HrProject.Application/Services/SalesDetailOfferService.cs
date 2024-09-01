using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class SalesDetailOfferService : BaseRepository<SalesDetailOffer>, ISalesDetailOfferService
    {
        public SalesDetailOfferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IEnumerable<SalesDetailOffer> GetIncludeSalesDetailOffer()
        {
            var result = _context.SalesDetailOffers.Include(x => x.PurchaseVat).Include(x => x.Stock).ToList();

            return result;
        }
    }
}
