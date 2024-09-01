using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PersonelDocumentService : BaseRepository<PersonelDocument>, IPersonelDocumentService
    {
        public PersonelDocumentService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IEnumerable<PersonelDocument> GetIncludePerDoc()
        {
            var result = _context.PersonelDocuments.Include(x => x.PersonelAuthority).ToList();

            return result;
        }
    }
}
