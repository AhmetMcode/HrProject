using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ICurrentValueService : IBaseRepository<CurrentValue>
    {
        List<CurrentValue> GetCurrentValuesByInclude();
        public bool UpdateCurrentValueWithChange(int currentValueId, decimal price);
    }
}
