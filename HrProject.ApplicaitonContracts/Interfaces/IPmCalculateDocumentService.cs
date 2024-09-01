using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IPmCalculateDocumentService : IBaseRepository<PmCalculateDocuments>
    {
        public List<PmCalculateDocuments> GetByPmId(int id);


    }
}
