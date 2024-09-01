using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class InvoiceStockService : BaseRepository<InvoiceStock>, IInvoiceStockService
    {
        public InvoiceStockService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public InvoiceStock GetInvoiceStockInclude(int id)
        {
            return _context.InvoiceStocks.Include(x => x.InvoiceStockTaxs).Include(x => x.InvoiceStockDiscounts).Include(x => x.StockChanges).Include(x => x.StockChanges).ThenInclude(x => x.Stock).Include(x => x.StockChanges).ThenInclude(x => x.ExitWareHouse).Include(x => x.Unit).Include(x => x.SaleVat).Include(x => x.Invoice).Where(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<InvoiceStock> GetIncludeInvoiceStock()
        {
            var invoices = _context.InvoiceStocks.Include(x => x.InvoiceStockTaxs).Include(x => x.InvoiceStockDiscounts).Include(x => x.StockChanges).Include(x => x.StockChanges).ThenInclude(x => x.Stock).Include(x => x.StockChanges).ThenInclude(x => x.ExitWareHouse).Include(x => x.Unit).Include(x => x.SaleVat).Include(x => x.Invoice).ToList();
            return invoices;
        }

        public InvoiceStock CalculateInoviceStock(int id)
        {
            var invoiceStock = GetInvoiceStockInclude(id);
            decimal birimcarpiAdet = invoiceStock.Quantity * invoiceStock.UnitPrice;
            decimal malhizmetTutari = birimcarpiAdet;
            foreach (var item in invoiceStock.InvoiceStockDiscounts)
            {
                malhizmetTutari = (malhizmetTutari - (malhizmetTutari * (item.DiscountRate / 100)));
            }
            foreach (var item in invoiceStock.InvoiceStockTaxs)
            {
                malhizmetTutari = (malhizmetTutari - (malhizmetTutari * (item.TaxRate / 100)));

            }
            decimal kdvHaric = malhizmetTutari;
            invoiceStock.GoodsOrServiceAmount = kdvHaric;
            malhizmetTutari += malhizmetTutari * invoiceStock.SaleVat.VATRate;
            invoiceStock.AmountIncludingVat = malhizmetTutari;
            _context.InvoiceStocks.Update(invoiceStock);
            _context.SaveChanges();
            var inf = GetInvoiceStockInclude(id);
            inf.Invoice = null;
            return inf;
        }
    }
}
