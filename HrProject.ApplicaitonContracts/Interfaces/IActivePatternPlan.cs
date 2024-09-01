using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IActivePatternPlan : IBaseRepository<ActivePatternPlan>
    {
        public List<ActivePatternPlan> GetActivePatternPlansByIdInclude(int id);
        public List<ActivePatternPlan> GetAllInclude();
        public ProductPlan GetByProjectId(int id);
        public ProductPlan GetByOfferId(int id);
        public List<ProductPlan> GetAllPlans();
        public DateTime GetAviablePatternDate(int patternId);
        public void UpdateTerminSubOnlyPlan(OfferTerminSub offerTerminSub);
    }
}
