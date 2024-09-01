using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PersonSalaryService : BaseRepository<PersonSalary>, IPersonSalaryService
    {
        public PersonSalaryService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public PersonSalary GetByDeleteSalary(int id)
        => _context.PersonSalaries.FirstOrDefault(x => x.Id == id && x.IsActive == false);

        public PersonSalary GetBySalary(int id)
        => _context.PersonSalaries.FirstOrDefault(x => x.PersonId == id && x.IsActive == true);

        public IEnumerable<PersonSalary> GetPersonSalaries(int id)
        {
            var result = _context.PersonSalaries
                          .Where(salary => salary.PersonId == id)
                          .ToList();

            return result;
        }
    }
}
