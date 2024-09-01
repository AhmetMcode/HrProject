using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IOfferMessageService : IBaseRepository<OfferMessages>
    {

        public OfferMessages GetByAddId(int offerId);
        public void AddMessageDetail(int messageId, string content, string userId);
    }
}
