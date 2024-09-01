using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class SubFirstOfferService : BaseRepository<SubFirstOffer>, ISubFirstOfferService
    {
        public SubFirstOfferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void AddSubFirstOffer(string name, string userId)
        {
            SubFirstOffer subFirstOffer = new SubFirstOffer();
            subFirstOffer.Name = name;
            subFirstOffer.StarterUserId = userId;
            subFirstOffer.CreatedTime = DateTime.Now;
            _context.Add(subFirstOffer);
            _context.SaveChanges();
        }

        public List<SubFirstOffer> GetAllByInclude()
        {
            return _context.SubFirstOffers.Include(x => x.StarterUser).ToList();
        }
    }
}
