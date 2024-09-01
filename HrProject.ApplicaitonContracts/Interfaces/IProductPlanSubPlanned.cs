using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProductPlanSubPlanned : IBaseRepository<ProductPlanSubPlanned>
    {
        public List<ProductPlan> GetAllProductPlan();
        public List<ProductPlanProductPlanned> GetProductPlanPlannedByProjectId(int projectId);
    }
}
