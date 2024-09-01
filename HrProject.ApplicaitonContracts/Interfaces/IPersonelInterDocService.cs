using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IPersonelInterDocService : IBaseRepository<PersonelInterDoc>
    {
        public IEnumerable<PersonelInterDoc> GetIncludePerInterDoc();
    }


}
