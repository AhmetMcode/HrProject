using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PersonelInterDocService : BaseRepository<PersonelInterDoc>, IPersonelInterDocService
    {
        public PersonelInterDocService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IEnumerable<PersonelInterDoc> GetIncludePerInterDoc()
        {
            var result = _context.PersonelInterDocs.Include(y => y.Person).Include(x => x.PersAddDocs).ThenInclude(xl => xl.PersonelDocument).ToList();
            return result;
        }
    }
}
