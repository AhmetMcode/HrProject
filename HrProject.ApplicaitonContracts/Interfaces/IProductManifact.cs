using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProductManifact : IBaseRepository<ProductManifact2>
    {
        public Task Ekle(List<ProductManifact2> productManifact);
        public Task Start(List<ProductManifact2> productManifact);
        public List<ProductManifact2> GetIncludeByDateDemir(DateTime dateTime);
        public List<ProductManifact2> GetIncludeByDateBeton(DateTime dateTime);
        public List<ProductManifact2> GunPlanaGoreUretimDetaylar(ProductPlanDailyPlanned productPlanDailyPlanneds);
        public List<ProductManifact2> GetlAllManifactsPmCalculateIds(List<int> pmCalculateIds);
        public List<ProductManifact2> GetIncludeByOld();
        public List<ProductManifact2> GetByProjectId(int id);
        public List<ProductManifact2> UruneGoreGetir(int[] idler);
        public ProductManifact2 GetByProductPlanId(int productPlanId);
        public ProductManifact2 OnlyManifactGetByProductPlanId(int productPlanId);
        public Task StartManifactDetail(int detailId);
        public Task EndManifactDetail(int detailId);
        public List<ManifactStepType> GetlAllManifactStepType();
        public List<ProductManifact2> GetIncludeByDate(DateTime dateTime, int productionPlace);
    }
}
