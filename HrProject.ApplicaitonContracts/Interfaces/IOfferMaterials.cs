using HrProject.Domain.Entities;
using HrProject.Domain.Entities.Base;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IOfferMaterials : IBaseRepository<OfferMaterials>
    {
        public void Add(OfferMaterials offerMaterial);
        public List<OfferMaterials> GetAllInclude();
        public void SaveJsonOfferMaterialDetail(List<OfferCostCalculateDetail> details);
    }
}
