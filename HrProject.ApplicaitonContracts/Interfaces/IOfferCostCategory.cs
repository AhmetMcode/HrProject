using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IOfferCostCategory : IBaseRepository<OfferCostCategory>
    {
        OfferCostCategory GetInclude(int id);
        List<OfferCostCategory> GetAllInclude();
        List<OfferCostCalculateDetail> OfferCostCalculateDetailsAddAndList(int offerPartId);
    }
}
