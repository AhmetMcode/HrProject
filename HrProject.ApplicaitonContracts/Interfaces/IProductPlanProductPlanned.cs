using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProductPlanProductPlannedService : IBaseRepository<ProductPlanProductPlanned>
    {
        public List<ProductPlanProductPlanned> TariheGoreUrunler(DateTime tarih);
    }
}
