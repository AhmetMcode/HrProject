using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProductionStepService : IBaseRepository<ProductionStep>
    {
        public List<ProductionStep> GetByProjectElementId(int projectElementId);
        public List<ManifactStepType> GetManifactStepTypes();

    }
}
