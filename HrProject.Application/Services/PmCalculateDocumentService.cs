using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PmCalculateDocumentService : BaseRepository<PmCalculateDocuments>, IPmCalculateDocumentService
    {
        public PmCalculateDocumentService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<PmCalculateDocuments> GetByPmId(int id)
        {
            var pmDocs = _context.PmCalculateDocuments.Where(x => x.PmCalculateId == id).ToList();
            return pmDocs;
        }
    }
}
