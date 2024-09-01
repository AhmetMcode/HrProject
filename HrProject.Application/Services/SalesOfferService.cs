using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class SalesOfferService : BaseRepository<SalesOffer>, ISalesOfferService
    {
        public SalesOfferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IEnumerable<SalesOffer> GetIncludeSalesOffer()
        {
            var result = _context.SalesOffers
                .Include(x => x.CariKart)
                .Include(x => x.SalesDetailOffers)
                    .ThenInclude(sd => sd.Stock)
                .Include(x => x.SalesDetailOffers)
                    .ThenInclude(sd => sd.PurchaseVat)
                .ToList();

            return result;
        }



        public SalesOffer GetIncludeSalesOfferById(int id)
        {
            var salesOffer = _context.SalesOffers
         .Include(x => x.CariKart)
         .Include(x => x.SalesDetailOffers)
             .ThenInclude(sd => sd.Stock)
         .Include(x => x.SalesDetailOffers)
             .ThenInclude(sd => sd.PurchaseVat)
         .Where(x => x.Id == id)
         .FirstOrDefault();

            return salesOffer;

        }
    }
}
