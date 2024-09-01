using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ISubFirstOfferService : IBaseRepository<SubFirstOffer>
    {
        public List<SubFirstOffer> GetAllByInclude();
        public void AddSubFirstOffer(string name, string userId);
    }
}
