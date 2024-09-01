using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IPatternService : IBaseRepository<Pattern>
    {
        public List<ProjectElementType> MyProjectElements(int PatternId);
        public Pattern GetByIdInclude(int PatternId);
        public List<Pattern> GetByAllInclude();
        public List<PatternProjectElementType> MyPatternProjectElements(int PatternId);
        public List<ProductPlanSubPlanned> GetAlldProductPlanSubPlanned();
        public ProductPlanSubPlanned GetProductPlanSubPlannedById(int id);
        public List<ProductPlanDailyPlanned> GetAllProductPlanDailyPlanned();
        public List<ProductPlanDailyPlanned> GetProductPlanDailyPlannedByPatternId(int PatternId);
        public List<ProductPlanDailyPlanned> GetProductPlanSubPlannedByPatternId(int PatternId);
        public List<ProductPlanProductPlanned> GetProductPlanPlannedByPatternId(int PatternId);
        public List<ProductManifact2> GetProductManifactByPatternId(int PatternId);
        public List<ProductPlanProductPlanned> GetProductPlanPlannedByPatternIdAndDate(int PatternId, DateTime tarih);
        public List<ProductPlanProductPlanned> GetAllProductPlanProductPlanned();
        public List<ProductPlan> GetAllProductPlan();
        public ProductPlan GetProductPlanByProjeId(int ProjectId);
        public ProductPlanSubPlanned AddProductPlanSubPlanned(ProductPlanSubPlanned productPlanSubPlanned);
        public ProductManifact2 GetProductManifactsByProductPlanId(int productPlanId);
        public void AddProductPlan(ProductPlan productPlanSub);
        public void AddProductPlanDailyPlanned(ProductPlanDailyPlanned productPlanSubPlanned);
        public void AddPattenPorjectElement(PatternProjectElementType patternProjectElementType);
        public void DeletePattenPorjectElement(int PatternId, int ProjectElementTypeId);
        public Task RePlanByDailyId(int dailyId, DateTime newDate, string secim);
        public Task RePlanProduct(int productId, DateTime newDate, string secim);
        public Task UrunGunDegistir(int productId, DateTime newDate);
    }
}
