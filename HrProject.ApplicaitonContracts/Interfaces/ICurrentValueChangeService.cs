using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ICurrentValueChangeService : IBaseRepository<CurrentValueChange>
    {
        public void UpdateValueChange(int currentValueId, decimal price);
        public List<CurrentValueChange> GetByListCurrentValueId(int currentValueId);
    }

}
