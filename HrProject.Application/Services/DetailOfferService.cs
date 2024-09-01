using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class DetailOfferService : BaseRepository<DetailOffer>, IDetailOfferService
    {
        public DetailOfferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public List<DetailOffer> GetAllDetailOffer()
        {
            var result = _context.DetailOffers.Include(x => x.CariKart).Include(x => x.GoodsCode).Include(x => x.Stock).Include(x => x.PurchaseVat);
            return result.ToList();
        }
        public List<DetailOffer> GetIncludeDetailOffersById(int id)
        {
            var result = _context.DetailOffers.Include(x => x.GoodsCode).Include(x => x.PurchaseVat).Include(x => x.Stock).Include(x => x.CariKart).Include(x => x.FirstOffer).Include(x => x.FirstOffer).Where(x => x.FirstOfferId == id);
            return result.ToList();
        }

    }
}
