using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProductStepNotifService : IBaseRepository<ProductStepNotif>
    {
        public List<ProductStepNotif> GetByStepIdInclude(int id);
    }
}
