using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class InvoiceStockTaxService : BaseRepository<InvoiceStockTax>, IInvoiceStockTaxService
    {
        public InvoiceStockTaxService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
