using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IPersonelDocumentService : IBaseRepository<PersonelDocument>
    {
        IEnumerable<PersonelDocument> GetIncludePerDoc();
    }
}
