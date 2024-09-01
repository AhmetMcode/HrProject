using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProjectElementTypeService : IBaseRepository<ProjectElementType>
    {
        List<ProjectElementType> GetProjectElementTypesByInclude();
        List<OfferTechnical> GetOfferTechnicals();
        void AddOfferTechnicals(OfferTechnical offerTechnical);
        void DeleteOfferTech(int id);
        void UpdateOfferTech(OfferTechnical offerTechnical);
    }
}
