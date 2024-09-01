using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ICustomerInteractionOfferService : IBaseRepository<CustomerInteractionOffer>
    {
        List<CustomerInteractionOffer> GetIncludeByOfferId(int offerId);
    }
}
