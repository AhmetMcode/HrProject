using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ISalesOfferService : IBaseRepository<SalesOffer>
    {
        IEnumerable<SalesOffer> GetIncludeSalesOffer();
        public SalesOffer GetIncludeSalesOfferById(int id);

    }
}
