using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class FirstOfferService : BaseRepository<FirstOffer>, IFirstOfferService
    {
        public FirstOfferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public List<FirstOffer> GetIncludeFirstOffers()
        {
            var result = _context.FirstOffers.Include(x => x.GoodsCode).Include(x => x.SubFirstOffer);
            return result.ToList();
        }

        public List<FirstOffer> GetIncludeFirstOffersBySubId(int id)
        {
            var result = _context.FirstOffers.Include(x => x.GoodsCode).Include(x => x.SubFirstOffer).Where(x => x.SubFirstOfferId == id);
            return result.ToList();
        }

        public List<FirstOffer> GetIncludeFirstOffersBySubIdAndName(int id, string name)
        {
            return _context.FirstOffers.Include(x => x.GoodsCode).Include(x => x.SubFirstOffer).Where(x => x.SubFirstOfferId == id)
                .ToList();
        }
    }
}
