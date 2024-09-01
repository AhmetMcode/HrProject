using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IHolNesneService : IBaseRepository<HolNesne>
    {
        public List<HolNesne> GetAllInclude();
    }
}
