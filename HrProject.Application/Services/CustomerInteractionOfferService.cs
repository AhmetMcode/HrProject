using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class CustomerInteractionOfferService : BaseRepository<CustomerInteractionOffer>, ICustomerInteractionOfferService
    {
        public CustomerInteractionOfferService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<CustomerInteractionOffer> GetIncludeByOfferId(int offerId)
        {
            return _context.CustomerInteractionOffers.Where(x => x.OfferId == offerId).Include(x => x.ApplicationUser).ToList();
        }
    }
}
