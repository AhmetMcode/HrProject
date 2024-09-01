using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProductDailyPlanService : IBaseRepository<ProductPlanDailyPlanned>
    {
        public List<ProductPlanDailyPlanned> BuKaliptakiSon2UretimEmri(int patternId);
        public ProductPlanDailyPlanned BuKaliptakiSonUretilmeyen(int patternId);
        public List<ProductPlanDailyPlanned> GetByKalipId(int patternId, DateTime baslangic, DateTime bitis);
    }
}
