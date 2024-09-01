using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IPersonService : IBaseRepository<Person>
    {
        IEnumerable<Person> GetPersonInclude();
        Person GetPersonInclude(int id);
        IEnumerable<Person> GetPersonList(string personelName, string tcNo, int? positionId, int? workplaceId, string phoneNumber, string IBAN, int? workingTime); Person GetByIdIncDepartman(int id);
        public Task CalculateSskSalary(int personId, DateTime tarih);
        Task<Person?> GetPersonByIdAsync(int personId);
        Task<List<Person>> GetAllPersonsAsync();
    }
}
