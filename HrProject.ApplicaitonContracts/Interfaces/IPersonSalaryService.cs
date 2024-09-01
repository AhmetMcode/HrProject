using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IPersonSalaryService : IBaseRepository<PersonSalary>
    {
        PersonSalary GetBySalary(int id);
        IEnumerable<PersonSalary> GetPersonSalaries(int id);
        PersonSalary GetByDeleteSalary(int id);
    }
}
