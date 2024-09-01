using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IConcreteRequest : IBaseRepository<ConcreteRequest>
    {
        public List<ConcreteRequest> GetConcreteRequestByPlaceIdInclude(int id);
    }
}
