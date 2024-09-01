using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IFirstOfferService : IBaseRepository<FirstOffer>
    {
        List<FirstOffer> GetIncludeFirstOffers();
        List<FirstOffer> GetIncludeFirstOffersBySubId(int id);
        List<FirstOffer> GetIncludeFirstOffersBySubIdAndName(int id, string name);
    }
}
