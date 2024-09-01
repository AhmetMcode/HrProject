using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class InvoiceSubWaybillService : BaseRepository<InvoiceSubWaybill>, IInvoiceSubWaybillService
    {
        public InvoiceSubWaybillService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public IEnumerable<InvoiceSubWaybill> GetIncludeISubWayBill()
        {
            var subwaybill = _context.InvoiceSubWaybills.Include(x => x.OutWaybill2).ToList();
            return subwaybill;
        }
    }
}
