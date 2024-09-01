using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IDetailOfferService : IBaseRepository<DetailOffer>
    {
        public List<DetailOffer> GetAllDetailOffer();

        public List<DetailOffer> GetIncludeDetailOffersById(int id);


    }
}
