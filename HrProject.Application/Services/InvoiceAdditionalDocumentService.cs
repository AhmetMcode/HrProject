using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class InvoiceAdditionalDocumentService : BaseRepository<InvoiceAdditionalDocument>, IInvoiceAdditionalDocumentService
    {
        public InvoiceAdditionalDocumentService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
