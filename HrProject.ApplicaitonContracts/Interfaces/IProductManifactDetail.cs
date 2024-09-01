using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProductManifactDetail : IBaseRepository<ProductManifactDetail>
    {
        public ProductManifactDetail GetByIdInclude(int id);
        public ProductManifactDetail GetByActiveManifactInclude(int id);
        public ProductManifactDetail GetByIdNextInclude(int id);
        public void AddImageForStep(int id, string resim);
    }
}
