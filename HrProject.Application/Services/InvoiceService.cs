using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class InvoiceService : BaseRepository<Invoice>, IInvoiceService
    {
        public InvoiceService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public Invoice GetInvoiceInclude(int id)
        {
            return _context.Invoices.Include(x => x.InvoiceStocks).ThenInclude(x => x.InvoiceStockDiscounts).Include(x => x.InvoiceStocks).ThenInclude(x => x.InvoiceStockTaxs).Include(x => x.InvoiceStocks).ThenInclude(x => x.StockChanges).ThenInclude(x => x.Stock).Include(x => x.CariKart).Include(x => x.InvoiceStocks).Include(x => x.InvoiceSubWaybills).Include(x => x.InvoiceAdditionalDocuments).Include(x => x.InvoiceGoodsAcceptances).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Invoice> GetIncludeInvoice()
        {
            var invoices = _context.Invoices.Include(x => x.InvoiceStocks).ThenInclude(x => x.InvoiceStockDiscounts).Include(x => x.InvoiceStocks).ThenInclude(x => x.InvoiceStockTaxs).Include(x => x.InvoiceStocks).ThenInclude(x => x.StockChanges).ThenInclude(x => x.Stock).Include(x => x.CariKart).Include(x => x.InvoiceStocks).Include(x => x.InvoiceSubWaybills).Include(x => x.InvoiceAdditionalDocuments).Include(x => x.InvoiceGoodsAcceptances).ToList();
            return invoices;
        }

        public async Task AddInvoice(Invoice invoice)
        {
            invoice.Account2Id = null;
            _context.Invoices.Add(invoice);
            try
            {

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CariKart GetCariById(int id)
        {
            var carikart = _context.CariKarts
            .Include(x => x.TaxOffice)
            .Where(c => c.Id == id)
            .FirstOrDefault();

            return carikart;
        }
        public InvoiceAdress GetInvoiceAdressByCariId(int id)
        {
            var invoiceadres = _context.InvoiceAdress
                   .Include(x => x.City).Include(x => x.District)
                   .Where(x => x.CariKartId == id && x.DefaultAddress == true)
                   .FirstOrDefault();
            return invoiceadres;
        }

        public async Task FaturaToplamGuncelleme(int faturdaId)
        {
            var fatura = GetInvoiceInclude(faturdaId);

            fatura.TotalInvoiceBaseAmount = 0;
            fatura.TotalInvoiceDiscount = 0;
            fatura.TotalInvoicemountWithoutTax = 0;
            fatura.TotalInvoicemountWithTax = 0;
            fatura.TotalInvoicemountPaid = 0;

            foreach (var item in fatura.InvoiceStocks)
            {
                fatura.TotalInvoiceBaseAmount += item.UnitPrice * item.Quantity;
                fatura.TotalInvoicemountPaid += item.AmountIncludingVat;

                if (item.InvoiceStockDiscounts != null)
                {
                    fatura.TotalInvoiceDiscount += item.InvoiceStockDiscounts.Sum(x => x.DiscountAmount);
                }

                if (item.InvoiceStockTaxs != null)
                {
                    fatura.TotalInvoicemountWithoutTax += item.GoodsOrServiceAmount - item.InvoiceStockTaxs.Sum(x => x.TaxAmount);
                    fatura.TotalInvoicemountWithTax += item.GoodsOrServiceAmount + item.InvoiceStockTaxs.Sum(x => x.TaxAmount);
                }

            }
            try
            {
                _context.Invoices.Update(fatura);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
