using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class InvoiceStockDiscountService : BaseRepository<InvoiceStockDiscount>, IInvoiceStockDiscountService
    {
        public InvoiceStockDiscountService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
